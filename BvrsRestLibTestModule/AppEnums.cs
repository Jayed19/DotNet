using System;
using System.Reflection;

namespace BvrsRestLibTestModule
{
    public enum Role
    {
        [SuperType("Role")]
        [StringCode("ROLE_DEFAULT_ADMIN")]
        [IntCode(99)]
        [StringValue("Default Admin")]
        ROLE_DEFAULT_ADMIN,

        [SuperType("Role")]
        [StringCode("BIOENROLL_ADMIN")]
        [IntCode(10)]
        [StringValue("Admin [Bio-Enroll]")]
        BIOENROLL_ADMIN,

        [SuperType("Role")]
        [StringCode("BIOENROLL_TEAMLEAD")]
        [IntCode(11)]
        [StringValue("Team Lead")]
        BIOENROLL_TEAMLEAD,

        [SuperType("Role")]
        [StringCode("BIOENROLL_VALIDATOR")]
        [IntCode(12)]
        [StringValue("Proof-Checker")]
        BIOENROLL_VALIDATOR,

        [SuperType("Role")]
        [StringCode("BIOENROLL_OPERATOR")]
        [IntCode(13)]
        [StringValue("Operator")]
        BIOENROLL_OPERATOR,

        [SuperType("Role")]
        [StringCode("BIOENROLL_OPERATOR_VALIDATOR")]
        [IntCode(14)]
        [StringValue("Operator / Proof-Checker")]
        BIOENROLL_OPERATOR_VALIDATOR,

        [SuperType("Role")]
        [StringCode("administrator")]
        [IntCode(1)]
        [StringValue("Admin [Uploader]")]
        UPLOADER_ADMIN,

        [SuperType("Role")]
        [StringCode("uploader")]
        [IntCode(3)]
        [StringValue("Uploader")]
        UPLOADER_OPERATOR
    }

    public enum ApplicantType : int
    {
        [SuperType("ApplicantType")]
        [StringCode("bangladeshi")]
        [StringValue("বাংলাদেশী")]
        APPLICANT_TYPE_BANGLADESHI,
        [SuperType("ApplicantType")]
        [StringCode("foreign_bangladeshi")]
        [StringValue("প্রবাসী বাংলাদেশী")]
        APPLICANT_TYPE_FOREIGN_BANGLADESHI
    }

    public enum EnrollmentLocation : int
    {
        [SuperType("EnrollmentLocation")]
        [StringCode("bangladesh")]
        [StringValue("দেশে")]
        BANGLADESH,
        [SuperType("EnrollmentLocation")]
        [StringCode("foreign")]
        [StringValue("প্রবাসে")]
        FOREIGN
    }

    public enum SetupMode : int
    {
        [SuperType("SetupMode")]
        [StringCode("open")]
        [StringValue("উন্মুক্ত")]
        OPEN,
        [SuperType("SetupMode")]
        [StringCode("bangladesh")]
        [StringValue("বাংলাদেশ")]
        BANGLADESH,
        [SuperType("SetupMode")]
        [StringCode("foreign")]
        [StringValue("")]
        FOREIGN
    }

    public class StringValueAttribute : System.Attribute
    {
        private String _value;
        public StringValueAttribute(String value)
        {
            this._value = value;
        }
        public string Value
        {
            get { return _value; }
        }
    }

    public class StringCodeAttribute : System.Attribute
    {
        private String _value;
        public StringCodeAttribute(String value)
        {
            this._value = value;
        }
        public string Value
        {
            get { return _value; }
        }
    }

    public class IntCodeAttribute : System.Attribute
    {
        private int _value;
        public IntCodeAttribute(int value)
        {
            this._value = value;
        }
        public int Value
        {
            get { return _value; }
        }
    }

    public class SuperTypeAttribute : System.Attribute
    {
        private String _value;
        public SuperTypeAttribute(String value)
        {
            this._value = value;
        }
        public string Value
        {
            get { return _value; }
        }
    }

    public static class EnumExtensions
    {
        public static String GetStringValue(this Enum value)
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringValueAttribute[] attrs =
               fi.GetCustomAttributes(typeof(StringValueAttribute),
                                       false) as StringValueAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }

        public static String GetStringCode(this Enum value)
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringCodeAttribute[] attrs =
               fi.GetCustomAttributes(typeof(StringCodeAttribute),
                                       false) as StringCodeAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }

        public static int GetIntCode(this Enum value)
        {
            int output = -1;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            IntCodeAttribute[] attrs =
                fi.GetCustomAttributes(typeof(IntCodeAttribute),
                                        false) as IntCodeAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }

        public static String GetSuperType(this Enum value)
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            SuperTypeAttribute[] attrs =
               fi.GetCustomAttributes(typeof(SuperTypeAttribute),
                                       false) as SuperTypeAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }

    public enum CounterType
    {
        [SuperType("CounterType")]
        [StringCode("FIXED")]
        [IntCode(1)]
        [StringValue("Fixed")]
        FIXED,

        [SuperType("CounterType")]
        [StringCode("MOBILE")]
        [IntCode(2)]
        [StringValue("Mobile")]
        MOBILE,
    }
    public enum CounterStatus
    {
        [SuperType("CounterStatus")]
        [StringCode("ACTIVE")]
        [IntCode(1)]
        [StringValue("Active")]
        ACTIVE,

        [SuperType("CounterStatus")]
        [StringCode("INACTIVE")]
        [IntCode(2)]
        [StringValue("Inactive")]
        INACTIVE,
    }

    public enum OFFICE
    {
        [SuperType("HQ")]
        [StringCode("999")]
        [IntCode(1)]
        [StringValue("Head Office")]
        HQ,
    }

    public enum AppStatusServer
    {
        [SuperType("AppStatusServer")]
        [StringCode("Checked")]
        [IntCode(1)]
        [StringValue("Checked")]
        Checked,

        [SuperType("AppStatusServer")]
        [StringCode("halnagad_2019")]
        [IntCode(1)]
        [StringValue("halnagad_2019")]
        halnagad_2019,

        [SuperType("AppStatusServer")]
        [StringCode("copy_halnagad_2019")]
        [IntCode(1)]
        [StringValue("copy_halnagad_2019")]
        copy_halnagad_2019,

        [SuperType("AppStatusServer")]
        [StringCode("halnagad_2020")]
        [IntCode(1)]
        [StringValue("halnagad_2020")]
        halnagad_2020,
    }
}

