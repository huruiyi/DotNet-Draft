using 反射实例1.Attr;

namespace 反射实例1.Model
{
    public class Teacher
    {
        [Required("教师姓名不能为空")]
        public string TeacherName { get; set; }

        public string Post { get; set; }
    }
}