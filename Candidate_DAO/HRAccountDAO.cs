using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class HRAccountDAO
    {
        private readonly string filePath = Path.Combine("Data", "HRAccount.json");
        private static HRAccountDAO instance;

        private List<Hraccount> ReadFromFile()
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Hraccount>>(json) ?? new List<Hraccount>();
            }
            catch (Exception ex)
            {
                return new List<Hraccount>();
            }
        }

        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return ReadFromFile().SingleOrDefault(x => x.Email.Equals(email));
        }

    }
}
