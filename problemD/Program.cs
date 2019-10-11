using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace problemD {
    class Program {
        static Dictionary<string, Student> searchByName = new Dictionary<string, Student>();
        static Dictionary<string, Race> searchRaceByName = new Dictionary<string, Race>();
        static void Main(string[] args) {
            searchRaceByName.Add("大隊接力", new Race("大隊接力", false));
            searchRaceByName.Add("一顆球的距離", new Race("一顆球的距離", false));
            searchRaceByName.Add("天旋地轉", new Race("天旋地轉", false));
            searchRaceByName.Add("滾大球袋鼠跳", new Race("滾大球袋鼠跳", false));
            searchRaceByName.Add("牽手同心", new Race("牽手同心", false));
            searchRaceByName.Add("100公尺", new Race("100公尺", true));
            searchRaceByName.Add("400公尺接力", new Race("400公尺接力", true));
            searchRaceByName.Add("800公尺", new Race("800公尺", true));
            searchRaceByName.Add("跳高", new Race("跳高", true));
            while (true) {
                Console.WriteLine("請選擇操作項目：");
                Console.WriteLine("　　　　(1)批次輸入");
                Console.WriteLine("　　　　(2)選手查詢");
                Console.WriteLine("　　　　(3)刪除");
                Console.WriteLine("　　　　(4)逐筆輸入");
                Console.WriteLine("　　　　(5)顯示所有資料");
                Console.Write("請輸入：");
                int command = Convert.ToInt32(Console.ReadLine());
                if(command == 1) {
                    Console.Write("請輸入檔案路徑：");
                    String path = Console.ReadLine();
                    inputData(path);
                }else if(command == 2) {
                    Console.Write("請輸入 班級、學號、姓名：");
                    String input = Console.ReadLine();
                    String[] split = input.Split(' ');
                    searchData(split[2]);
                }else if(command == 3) {
                    Console.Write("刪除資料，請輸入 班級、學號、姓名、報名項目：");
                    String input = Console.ReadLine();
                    String[] split = input.Split(' ');
                    removeSubject(split[2],split[3]);
                    Console.WriteLine(String.Format("被刪除的選手資料：{0} {1} {2} {3}", split[0], split[1], split[2], split[3]));
                }else if(command == 4) {
                    Console.Write("逐筆輸入，請輸入 班級、學號、姓名、性別：");
                    String input = Console.ReadLine();
                    String[] split = input.Split(' ');
                    Console.WriteLine("報名項目");
                    for(int i = 0; i < searchRaceByName.Count; i++) {
                        KeyValuePair<String, Race> kvp = searchRaceByName.ElementAt(i);
                        Console.WriteLine(Convert.ToString((char)('a' + i)) + "：" + kvp.Key);
                    }
                    Console.Write("請選擇：");
                    String choose = Console.ReadLine();
                    register(split, (choose[0]-'a'));
                }else if(command == 5) {
                    print();
                }
                Console.Write("繼續請按1，結束請按0：");
                command = Convert.ToInt32(Console.ReadLine());
                if (command == 0) break;
            }
        }
        public static void inputData(String path) {
            StreamReader sr = new StreamReader(path);
            string line;
            while((line = sr.ReadLine()) != null) {
                String[] split = line.Split(' ');
                String cla = split[0];
                String num = split[1];
                String nam = split[2];
                String sex = split[3];
                String race = split[4];
                Student student;
                if (searchByName.ContainsKey(nam)) {
                    student = searchByName[nam];
                }
                else {
                    student = new Student(cla, num, nam, sex);
                }
                student.addRace(searchRaceByName[race]);
                searchByName[nam] = student;
            }
        }

        public static void searchData(String name) {
            if (searchByName.ContainsKey(name)) {
                Student student = searchByName[name];
                List<Race> race = student.getAllRace();
                for (int i = 0; i < race.Count; i++) {
                    Console.WriteLine(String.Format("{0} {1} {2} {3}", student.cla, student.number, student.name, race[i].raceName));
                }
            }
            else {
                Console.WriteLine("沒有資料");
            }
        }

        public static void removeSubject(String name, String raceName) {
            Student student = searchByName[name];
            Race race = searchRaceByName[raceName];
            student.removeRace(race);
        }

        public static void register(String[] data, int raceNum) {
            String name = data[2];
            Student student = null;
            int personal = 0, npersonal = 0;
            if (searchByName.ContainsKey(name)) {
                student = searchByName[name];
                List<Race> race = student.getAllRace();
                for (int i = 0; i < race.Count; i++) {
                    Console.WriteLine(String.Format("{0} {1} {2} {3}", student.cla, student.number, student.name, race[i].raceName));
                    if (race[i].personal == true) {
                        personal++;
                    }
                    else {
                        npersonal++;
                    }
                }
            }
            if(student == null) {
                student = new Student(data[0],data[1],data[2],data[3]);
                searchByName.Add(name, student);
            }
            Race newRace = searchRaceByName.ElementAt(raceNum).Value;
            Console.WriteLine(String.Format("輸入班級：{0}、學號：{1}、姓名：{2}、性別：{3}、報名項目：{4}", student.cla, student.number, student.name, student.sexual, newRace.raceName));
            if(newRace.personal == true && npersonal > 0) {
                Console.WriteLine("已報團體賽，不能再報名個人賽");
            }
            else if(newRace.personal == false && personal > 0){
                Console.WriteLine("已報個人賽，不能再報名團體賽");
            }else if(newRace.personal == true && personal >= 2) {
                Console.WriteLine("已報兩組個人賽，不能再報名了");
            }else if(newRace.personal == false && npersonal >= 2) {
                Console.WriteLine("已報兩組團體賽，不能再報名了");
            }
            else {
                student.addRace(newRace);
            }
            searchByName[name] = student;
        }
        public static void print() {
            for(int i = 0; i < searchByName.Count; i++) {
                Student student = searchByName.ElementAt(i).Value;
                List<Race> list = student.getAllRace();
                for(int j = 0; j < list.Count; j++) {
                    Console.WriteLine(String.Format("{0} {1} {2} {3} {4}", student.cla, student.number, student.name, student.sexual, list[j].raceName));
                }
            }
        }
    }
    
    public class Student {
        public string cla, name, number, sexual;
        List<Race> list = new List<Race>();
        public Student(String cla, string number, string name, string sexual) {
            this.cla = cla;
            this.number = number;
            this.name = name;
            this.sexual = sexual;
        }
        public void addRace(Race race) {
            list.Add(race);
        }
        public List<Race> getAllRace() {
            return list;
        }
        public void removeRace(Race race) {
            list.Remove(race);
        }
    }
    public class Race {
        public string raceName;
        public bool personal;
        public Race(String name, bool personal) {
            raceName = name;
            this.personal = personal;
        }
    }
}//finish at 87min
