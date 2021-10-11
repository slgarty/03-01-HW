using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _3_03_HW.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class PersonDb
    {
        private readonly string _connectionstring;
        public PersonDb(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        public List<Person> GetPeople()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = ("select * from borrowers");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Person> people = new List<Person>();
                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        Id = (int)reader["id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Age = (int)reader["age"]
                    });
                }
                return people;
            }


        }
        public void AddPeople(List<Person>people)
        {
            foreach (Person p in people)
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = ("insert into borrowers values( @FirstName, @LastName, @Age)");
                    command.Parameters.AddWithValue("@FirstName", p.FirstName);
                    command.Parameters.AddWithValue("@LastName", p.LastName);
                    command.Parameters.AddWithValue("@Age", p.Age);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
    }
    public class PersonViewModel
    {
        public List<Person> People { get; set; }
    }
}
