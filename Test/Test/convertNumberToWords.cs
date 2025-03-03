using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class convertNumberToWords
    {
        public string ChuyenSoSangChu(int number)
        {
            if (number < 0)
                return "Số không hợp lệ";

            if (number == 0)
                return "Không đồng";

            string[] mNumText = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] unitText = { "", "nghìn", "triệu", "tỷ" };

            string sNumber = number.ToString();  // Chuyển `int` thành `string` để dễ thao tác
            int length = sNumber.Length;
            int groupCount = (length + 2) / 3; // Chia số thành từng nhóm 3 chữ số
            int firstGroupSize = length % 3 == 0 ? 3 : length % 3; // Nhóm đầu tiên có thể không đủ 3 số

            StringBuilder result = new StringBuilder();
            int index = 0;
            bool hasPreviousGroup = false;

            for (int i = 0; i < groupCount; i++)
            {
                int groupSize = (i == 0) ? firstGroupSize : 3;
                string group = sNumber.Substring(index, groupSize);
                index += groupSize;

                // 🔹 Kiểm tra nếu là nhóm đầu tiên
                string groupWords = ConvertThreeDigitGroup(int.Parse(group), mNumText, i == 0);

                if (!string.IsNullOrEmpty(groupWords))
                {
                    if (hasPreviousGroup)
                        result.Append(" ");

                    result.Append(groupWords).Append(" ").Append(unitText[groupCount - i - 1]);
                    hasPreviousGroup = true;
                }
            }

            string finalResult = StandardizeVietnameseNumbers(result.ToString().Trim());

            return char.ToUpper(finalResult[0]) + finalResult.Substring(1) + " đồng";
        }

        private static string ConvertThreeDigitGroup(int num, string[] mNumText, bool isFirstGroup = false)
        {
            if (num == 0) return "";

            StringBuilder words = new StringBuilder();

            if (num >= 100)
            {
                words.Append(mNumText[num / 100]).Append(" trăm");
                num %= 100;

                if (num > 0)
                    words.Append(" ");
            }

            if (num >= 10)
            {
                int tens = num / 10;
                int ones = num % 10;

                if (tens == 1)
                    words.Append("mười");
                else
                    words.Append(mNumText[tens]).Append(" mươi");

                if (ones > 0)
                {
                    words.Append(" ").Append(ones == 1 ? "mốt" : ones == 5 ? "lăm" : mNumText[ones]);
                }
            }
            else if (num > 0)
            {
                // 🔹 Nếu là nhóm số đầu tiên (triệu, tỷ), bỏ từ "linh"
                if (!isFirstGroup)
                    words.Append("linh ");

                words.Append(mNumText[num]);
            }

            return words.ToString().Trim();
        }


        private static string StandardizeVietnameseNumbers(string text)
        {
            var replacements = new Dictionary<string, string>
        {
            { "mươi bốn", "mươi tư" },
            { "linh bốn", "linh tư" },
            { "mươi năm", "mươi lăm" },
            { "mươi một", "mươi mốt" },
            { "mười năm", "mười lăm" },
            { "không mươi không", "" },
            { "không trăm linh", "không trăm" }
        };

            foreach (var pair in replacements)
            {
                text = text.Replace(pair.Key, pair.Value);
            }

            return text.Trim();
        }
    }
}
