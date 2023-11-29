using System.IO;
using System.Windows;

namespace SvgConverter
{
    public class ConvertedSvgData
    {
        private string _filepath;
        private string _xaml;
        private string _svg;
        private DependencyObject _convertedObj;
        private string _objectName;

        public string ObjectName
        {
            get
            {
                if(_objectName == null)
                {
                    // Force the object to convert to produce the object name
                    _ = ConvertedObj;
                }
                return _objectName;
            }

            private set => _objectName = value;
        }
        public string Filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }

        public string Xaml
        {
            get { return _xaml ?? (_xaml = ConverterLogic.SvgObjectToXaml(ConvertedObj, false, _objectName, false)); }
            set { _xaml = value; }
        }

        public string Svg
        {
            get { return _svg ?? (_svg = File.ReadAllText(_filepath)); }
            set { _svg = value; }
        }

        public DependencyObject ConvertedObj
        {
            get
            {
                if (_convertedObj == null)
                {
                    _convertedObj = ConverterLogic.ConvertSvgToObject(_filepath, ResultMode.DrawingImage, null, out _objectName, new ResKeyInfo()) as DependencyObject;
                }
                return _convertedObj;
            }
            set { _convertedObj = value; }
        }
    }
}
