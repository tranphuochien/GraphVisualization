using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
    class DCProfile : AbstractModel
    {
        
        private string mAlias;
        private string mRealName;
        private string mCity;
        private string mAlignment;
        private string mOccupation;
        private string mFacebook;
        private string mImgUrl;

        public DCProfile(
            long id,
            string alias,
            string realName,
            string city,
            string alignment,
            string occupation,
            string facebook,
            string imgUrl)
        {
            Id = id;
            Alias = alias;
            RealName = realName;
            City = city;
            Alignment = alignment;
            Occupation = occupation;
            Facebook = facebook;
            ImgUrl = imgUrl;
        }
        public string Alias
        {
            get
            {
                return mAlias;
            }

            set
            {
                mAlias = value;
            }
        }

        public string RealName
        {
            get
            {
                return mRealName;
            }

            set
            {
                mRealName = value;
            }
        }

        public string City
        {
            get
            {
                return mCity;
            }

            set
            {
                mCity = value;
            }
        }

        public string Alignment
        {
            get
            {
                return mAlignment;
            }

            set
            {
                mAlignment = value;
            }
        }

        public string Occupation
        {
            get
            {
                return mOccupation;
            }

            set
            {
                mOccupation = value;
            }
        }

        public string Facebook
        {
            get
            {
                return mFacebook;
            }

            set
            {
                mFacebook = value;
            }
        }

        public string ImgUrl
        {
            get
            {
                return mImgUrl;
            }

            set
            {
                mImgUrl = value;
            }
        }
    }
}
