using CourseApp.Data;
using CourseApp.Models;

string opt;
do
{

    Console.WriteLine("1.1. Create group");
    Console.WriteLine("1.2. Get group by Id");
    Console.WriteLine("1.3. Get all groups");
    Console.WriteLine("1.4. Update groups");
    Console.WriteLine("1.5. Delete groups");
    Console.WriteLine("1.6. Get group avg");
    Console.WriteLine("2.1. Create student");
    Console.WriteLine("2.2. Get studnet by Id");
    Console.WriteLine("2.3. Get students by group");


    Console.WriteLine("0. Exit");

    GroupDao groupDao = new GroupDao();
    StudentDao studentDao = new StudentDao();
    Console.WriteLine("Select an operation: ");
    opt = Console.ReadLine();

    switch (opt)
    {
        case "1.1":
            Console.WriteLine("\nEnter new group\n============");
            Console.Write("no: ");
            string no = Console.ReadLine();
            Console.Write("limit: ");
            byte limit = Convert.ToByte(Console.ReadLine());
            Group group = new Group { No = no, Limit = limit };

            groupDao.Insert(group);

            break;
        case "1.2":
            Console.WriteLine("\nEnter selected group id\n============");
            Console.Write("id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var data = groupDao.GetById(id);

            if (data == null) Console.WriteLine("Group not found");
            else Console.WriteLine(data);
            break;
        case "1.3":
            Console.WriteLine("\nAll groups\n============");
            foreach (var item in groupDao.GetAll())
            {
                Console.WriteLine(item + "-" + item.StudentsCount);
            }
            break;
        case "1.4":
            Console.WriteLine("\nEnter updated group\n============");
            Console.Write("id: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("no: ");
            no = Console.ReadLine();
            Console.Write("limit: ");
            limit = Convert.ToByte(Console.ReadLine());
            group = new Group(id, no, limit);
            var r = groupDao.Update(group);

            if (r == 0) Console.WriteLine("Group not found");
            else Console.WriteLine("group successfully updated");
            break;
        case "1.5":
            Console.WriteLine("\nEnter deleted group\n============");
            Console.Write("id: ");
            id = Convert.ToInt32(Console.ReadLine());
            groupDao.Delete(id);
            break;
        case "1.6":
            Console.WriteLine("\nEnter selected group\n============");
            Console.Write("id: ");
            id = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(GetStudentsAvgByGroupId(id));
            break;
        case "2.1":
            Console.WriteLine("\nEnter new student\n============");
            Console.Write("fullname: ");
            string fullname = Console.ReadLine();
            Console.Write("point: ");
            byte point = Convert.ToByte(Console.ReadLine());
            Console.Write("groupId: ");
            int groupId = Convert.ToInt32(Console.ReadLine());

            if(!groupDao.IsExists(groupId)) Console.WriteLine("Group not found by id: "+groupId);
            else
            {
                Student student = new Student
                {
                    Fullname = fullname,
                    Point = point,
                    GroupId = groupId
                };
                studentDao.Insert(student);
            }

            break;
        case "2.2":
            break;
        case "2.3":
            break;
        case "0":
            Console.WriteLine("Finished");
            break;
        default:
            Console.WriteLine("Wrong operation!");
            break;
    }

} while (opt != "0");
