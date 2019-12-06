using Hotels.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Hotels.Models
{
    public class BaseModel
    {
        public string Delete { get; set; } = "  حـذف  ";
        /*
        public Image image
        {
            get {
                //string bitmapPath = @"My%20Application;component/Images/add_new.png";
                ImageSource imageSource = new BitmapImage(new Uri("/Images/add_new.png"));
                BitmapImage bitmapImage = new BitmapImage(new Uri("/images/add_new.png"));
                return new Image() { Source = imageSource };
            }
            set { image = value; }
        }*/
    }
}
