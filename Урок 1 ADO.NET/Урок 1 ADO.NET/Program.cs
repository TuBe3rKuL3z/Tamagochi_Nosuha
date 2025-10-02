using System;
using System.Data.SqlClient;

namespace Урок__1__ADO.NET
{
    internal class Program
    {
        SqlConnection connection = null;
        //INSERT
        //string insertGroup = @"insert into Groups (GroupName, Spec, EduForm) values  ('9-ГД-23/1', 'Графический дизайн', 'Колледж')";
        //SELECT STRING
        string selectGroups = @"select * from Groups";
        string selectStudent = @"select * from Student";
        string selectTeacher = @"select * from Teacher";
        //UPDATE STRING
        string updateString = @"update GroupName set '9-РПО-25/1 where id = 1";
        //DELETE STRING
        string deleteString = @"delete from Groyps where id = 1";
        bool exit = false;

        //PROGRAM MENU
        public Program()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=College; Integrated Security=SSPI");
            Console.WriteLine("Создан объект подключения");
        }

        public void mainMenu()
        {
            Console.Clear();
            while (!exit)
            {
                Console.WriteLine("Выберите действие:\n" + 
                    "(1) Просмотр таблиц\n"+
                    "(2) Добавление в таблицу\n"+
                    "(3) Изменение таблицы\n"+
                    "(4) Удаление из таблицы\n"+
                    "(5) Выход\n");

                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Clear();
                    int a = userChoice();
                    if (a == 1)
                    {
                        SelectGroup();
                        Console.WriteLine("Нажмите Enter для продолжения");

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                    }
                    else if (a == 2)
                    {
                        SelectStudent();
                        Console.WriteLine("Нажмите Enter для продолжения");

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                    }
                    else if (a == 3)
                    {
                        SelectTeacher();
                        Console.WriteLine("Нажмите Enter для продолжения");

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                    }

                }
                else if (choice == 2)
                {
                    Console.Clear();
                    int a = userChoice();
                    if (a == 1)
                    {
                        InsertGroup();
                        Console.WriteLine("Нажмите Enter для продолжения");

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                    }
                    else if (a == 2)
                    {
                        InsertStudent();
                        Console.WriteLine("Нажмите Enter для продолжения");

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                    }
                    else if (a == 3)
                    {
                        InsertTeacher();
                        Console.WriteLine("Нажмите Enter для продолжения");

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (choice == 3)
                {
                    Console.Clear();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                }
                else if (choice == 5)
                {
                    Console.Clear();
                    return exit;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели не верное число. Повторите попытку!");
                }
            }
        }
        public int userChoice()
        {
            Console.WriteLine("Выбор таблицы:\n" +
                            "(1) Groups\n"+
                            "(2) Student\n"+
                            "(3) Teacher\n");
            
            int choice = Convert.ToInt32(Console.ReadLine());
            bool notRight = true;

            while (notRight)
            {
                if (choice == 1)
                {
                    return 1;
                }
                else if (choice == 2)
                {
                    return 2;
                }
                else if (choice == 3)
                {
                    return 3;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели не верное число. Повторите попытку!");
                }
            }
            return 0;
        }

        //SELECT FUNC
        public void SelectGroup()
        {
            SqlDataReader dataReader = null;
            try
            {
                connection.Open();
                Console.WriteLine("Создан объект читателя");
                SqlCommand sqlCommand = new SqlCommand(selectGroups, connection);
                Console.WriteLine("Создана команда на извлечение");
                dataReader = sqlCommand.ExecuteReader();
                Console.WriteLine("Чтение записей: ");
                Console.WriteLine("========================Чтение записей=====================");
                Console.WriteLine("===========================================================");
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader[0]}/t|/t{dataReader[1]}/t|/t{dataReader[2]}");
                }
                Console.WriteLine("===========================================================");
                Console.WriteLine("Конец записей");
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        public void SelectStudent()
        {
            SqlDataReader dataReader = null;
            try
            {
                connection.Open();
                Console.WriteLine("Создан объект читателя");
                SqlCommand sqlCommand = new SqlCommand(selectStudent, connection);
                Console.WriteLine("Создана команда на извлечение");
                dataReader = sqlCommand.ExecuteReader();
                Console.WriteLine("Чтение записей: ");
                Console.WriteLine("========================Чтение записей=====================");
                Console.WriteLine("===========================================================");
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader[0]}/t|/t{dataReader[1]}/t|/t{dataReader[2]}");
                }
                Console.WriteLine("===========================================================");
                Console.WriteLine("Конец записей");
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        public void SelectTeacher()
        {
            SqlDataReader dataReader = null;
            try
            {
                connection.Open();
                Console.WriteLine("Создан объект читателя");
                SqlCommand sqlCommand = new SqlCommand(selectTeacher, connection);
                Console.WriteLine("Создана команда на извлечение");
                dataReader = sqlCommand.ExecuteReader();
                Console.WriteLine("Чтение записей: ");
                Console.WriteLine("========================Чтение записей=====================");
                Console.WriteLine("===========================================================");
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader[0]}/t|/t{dataReader[1]}/t|/t{dataReader[2]}");
                }
                Console.WriteLine("===========================================================");
                Console.WriteLine("Конец записей");
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

       

        public void InsertQuery()
        {
            SqlConnection connection = null;
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=College; Integrated Security=SSPI");
            Console.WriteLine("Создан объект подключения");

            //Запрос на добавление
            string insertString = @"insert into Groups (GroupName, Spec, EduForm) values 
            ('9-ГД-23/1', 'Графический дизайн', 'Колледж')";

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertString;

            SqlCommand insertCmd = new SqlCommand(insertString, connection);
            Console.WriteLine("Создана команда на добавление");

            try
            {
                //Открывает соединение
                connection.Open();
                Console.WriteLine("Открыто соединение");
                //Выполняем запрос
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Выполнен запрос");
            }
            finally
            {
                //Закрываем соединение
                connection.Close();
                Console.WriteLine("Закрыто соединение");
            }

        }
        public void InsertQuery(string insertQuery)
        {
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertQuery;

            SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
            Console.WriteLine("Создана команда на добавление");

            try
            {
                //Открывает соединение
                connection.Open();
                Console.WriteLine("Открыто соединение");
                //Выполняем запрос
                //ExecuteNonQuery работает с запросами INSERT, UPDATE, DELETE
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Выполнен запрос");
            }
            finally
            {
                //Закрываем соединение
                connection.Close();
                Console.WriteLine("Закрыто соединение");
            }
        }

        //INSERT FUNC
        public void InsertGroup()
        {
            Console.WriteLine("Введите название группы: ");
            string groupName = Console.ReadLine();
            Console.WriteLine("Введите специалльность: ");
            string spec = Console.ReadLine();
            Console.WriteLine("Введите форму обучения: ");
            string eduForm = Console.ReadLine();


            string insertGroups = $@"insert into Groups (GroupName, Spec, EduForm) values  ('{groupName}', '{spec}', '{eduForm}')";


            //Запрос на добавление
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertGroups;

            SqlCommand insertCmd = new SqlCommand(insertGroups, connection);
            Console.WriteLine("Создана команда на добавление");

            try
            {
                //Открывает соединение
                connection.Open();
                Console.WriteLine("Открыто соединение");
                //Выполняем запрос
                //ExecuteNonQuery работает с запросами INSERT, UPDATE, DELETE
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Выполнен запрос");
            }
            finally
            {
                //Закрываем соединение
                connection.Close();
                Console.WriteLine("Закрыто соединение");
            }
        }
        public void InsertStudent()
        {
            Console.WriteLine("Введите Имя студента: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите Фамилию студента: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите Дату  рождения студента: ");
            string eduForm = Console.ReadLine();
            Console.WriteLine("Введите номер студенческого: ");
            int ticket = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер группы: ");
            int groupId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Зачетную книжку: ");
            int testBook = Convert.ToInt32(Console.ReadLine());


            string insertStudent = $@"insert into Groups (FirstName, LastName, BirthDay, Tichet, GroupId, TestBook) values  ('{firstName}', '{lastName}', '{eduForm}', {ticket}, {groupId}, {testBook})";


            //Запрос на добавление
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertStudent;

            SqlCommand insertCmd = new SqlCommand(insertStudent, connection);
            Console.WriteLine("Создана команда на добавление");

            try
            {
                //Открывает соединение
                connection.Open();
                Console.WriteLine("Открыто соединение");
                //Выполняем запрос
                //ExecuteNonQuery работает с запросами INSERT, UPDATE, DELETE
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Выполнен запрос");
            }
            finally
            {
                //Закрываем соединение
                connection.Close();
                Console.WriteLine("Закрыто соединение");
            }
        }
        public void InsertTeacher()
        {
            Console.WriteLine("Введите Имя учителя: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите Фамилию учителя: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите Дату устройства на работу: ");
            string wordDay = Console.ReadLine();
            Console.WriteLine("Введите категорию учителя: ");
            string category = Console.ReadLine();


            string insertTeacher = $@"insert into Groups (FirstName, LastName, WordDay, Category) values  ('{firstName}', '{lastName}', '{wordDay}', '{category}'";


            //Запрос на добавление
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertTeacher;

            SqlCommand insertCmd = new SqlCommand(insertTeacher, connection);
            Console.WriteLine("Создана команда на добавление");

            try
            {
                //Открывает соединение
                connection.Open();
                Console.WriteLine("Открыто соединение");
                //Выполняем запрос
                //ExecuteNonQuery работает с запросами INSERT, UPDATE, DELETE
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Выполнен запрос");
            }
            finally
            {
                //Закрываем соединение
                connection.Close();
                Console.WriteLine("Закрыто соединение");
            }
        }


        public void SelectQuery()
        {
            SqlDataReader dataReader = null;
            try
            {
                connection.Open();
                Console.WriteLine("Создан объект читателя");
                SqlCommand sqlCommand = new SqlCommand(selectGroups, connection);
                Console.WriteLine("Создана команда на извлечение");
                dataReader = sqlCommand.ExecuteReader();
                Console.WriteLine("Чтение записей: ");
                Console.WriteLine("========================Чтение записей=====================");
                Console.WriteLine("===========================================================");
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader[0]}/t|/t{dataReader[1]}/t|/t{dataReader[2]}");
                }
                Console.WriteLine("===========================================================");
                Console.WriteLine("Конец записей");
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if(connection != null)
                {
                    connection.Close();
                }
            }
        }



        static void Main(string[] args)
        {
            Program pr = new Program();
            //pr.SelectQuery();

            pr.mainMenu();
        }
    }
}


