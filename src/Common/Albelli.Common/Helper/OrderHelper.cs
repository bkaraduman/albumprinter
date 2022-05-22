using Albelli.Common.Models;
using Albelli.Common.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.Common.Helper
{
    public static class OrderHelper
    {
        private static Dictionary<ProductType, double> ProductTypePackageSize = new()
        {
            { ProductType.PhotoBook, 19 },
            { ProductType.Calendar, 10 },
            { ProductType.Canvas, 16 },
            { ProductType.Cards, 4.7 },
            { ProductType.Mug, 94 }
        };

        public static int CalculateRequiredBinWidth(List<ProductType> productTypes)
        {
            int requiredBinWidth = 0;
            int mugCounter = 0;

            foreach (var productType in productTypes)
            {
                if (productType == ProductType.Mug)
                    mugCounter++;

                if (productType != ProductType.Mug || mugCounter % 4 == 1)
                    requiredBinWidth += (int)ProductTypePackageSize[productType];

                if (mugCounter == 4)
                    mugCounter = 0;
            }

            return requiredBinWidth;
        }
    }
}
