using CSharpMobileComponents.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.DataStores
{
    public class SizesDataStore : BaseDataStore
    {
        public override string Name { get; set; } = "SIZES_DATA_STORE";

        public override void CleanDataStore()
        {
            return;
        }

        public int DeviceWidthPx
        {
            get
            {
                var width = DeviceDisplay.MainDisplayInfo.Width;
                return (int)Math.Floor(width);
            }
        }

        public int DeviceHeightPx
        {
            get
            {
                var height = DeviceDisplay.MainDisplayInfo.Height;
                return (int)Math.Floor(height);
            }
        }

        public int DeviceWidth
        {
            get
            {
                var xamarinFormsWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density; ;
                return (int)Math.Floor(xamarinFormsWidth);
            }
        }

        public int DeviceHeight
        {
            get
            {
                var xmarinFormsHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
                return (int)Math.Floor(xmarinFormsHeight);
            }
        }


        public string CurrentDeviceType { get { return GetDeviceType(); } }

        /// <summary>
        /// Key: Device Type
        /// Value: sizes used by the app
        /// </summary>
        public Dictionary<string, DeviceSizes> Sizes { get; set; }
        public Dictionary<string, ThicknessModel> Thicknesses { get; set; }

        private static SizesDataStore instance = null;
        public static SizesDataStore Instance
        {
            get
            {
                if (instance == null)
                    instance = new SizesDataStore();
                return instance;
            }
        }

        public SizesDataStore()
        {
            RegistDataStore();
            FillSizesDictionary();
            FillThicknessesDictionary();
        }

        private string GetDeviceType()
        {
            if (DeviceWidth <= 360)
                return DeviceTypes.Mobile.ToString();
            return DeviceTypes.Tablet.ToString();
        }

        private void FillSizesDictionary()
        {
            Sizes = new Dictionary<string, DeviceSizes>();
            Sizes.Add(AppDeviceSizes.Body.ToString(), new DeviceSizes()
            {
                MobileSize = 14,
                TabletSize = 24
            });
            Sizes.Add(AppDeviceSizes.ButtonControlHeight.ToString(), new DeviceSizes()
            {
                MobileSize = 42,
                TabletSize = 60
            });
            Sizes.Add(AppDeviceSizes.PrimaryOrSecondaryButtonControlCornerRadius.ToString(), new DeviceSizes()
            {
                MobileSize = 25,
                TabletSize = 33
            });
            Sizes.Add(AppDeviceSizes.PrimaryOrSecondaryButtonControlWidth.ToString(), new DeviceSizes()
            {
                MobileSize = (int)(double)(DeviceWidth / 1.2),
                TabletSize = 33
            });
        }

        private void FillThicknessesDictionary()
        {
            Thicknesses = new Dictionary<string, ThicknessModel>();
            Thicknesses.Add(AppDeviceThicknesses.SecondaryButtonMargin.ToString(), new ThicknessModel()
            {
                MobileThickness = 2,
                TabletThickness = 6
            });
            Thicknesses.Add(AppDeviceThicknesses.SecondaryButtonPadding.ToString(), new ThicknessModel()
            {
                MobileThickness = 0,
                TabletThickness = 6
            });
            Thicknesses.Add(AppDeviceThicknesses.ModalMargin.ToString(), new ThicknessModel()
            {
                MobileThickness = 6,
                TabletThickness = 6
            });
            Thicknesses.Add(AppDeviceThicknesses.MarginTop_1.ToString(), new ThicknessModel()
            {
                MobileThickness =  new Thickness( 0 , 2 , 0, 0),
                TabletThickness = 6
            });
            Thicknesses.Add(AppDeviceThicknesses.MarginTop_2.ToString(), new ThicknessModel()
            {
                MobileThickness = new Thickness(0, 4, 0, 0),
                TabletThickness = 6
            });
            Thicknesses.Add(AppDeviceThicknesses.MarginTop_3.ToString(), new ThicknessModel()
            {
                MobileThickness = new Thickness(0, 8, 0, 0),
                TabletThickness = 6
            });
            Thicknesses.Add(AppDeviceThicknesses.MarginTop_4.ToString(), new ThicknessModel()
            {
                MobileThickness = new Thickness(0, 16, 0, 0),
                TabletThickness = 6
            });
        }
    }
}
