using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostDAO
    {
        private readonly string filePath = Path.Combine("Data", "JobPosting.json");
        private static JobPostDAO instance;

        private List<JobPosting> ReadFromFile()
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<JobPosting>>(json) ?? new List<JobPosting>();
            }
            catch (Exception ex)
            {
                return new List<JobPosting>();
            }
        }

        public static JobPostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostDAO();
                }
                return instance;
            }
        }

        public List<JobPosting> GetJobPostings()
        {
            return ReadFromFile().ToList();
        }
        public JobPosting GetJobPosting(string jobId)
        {
            return ReadFromFile().SingleOrDefault(m => m.PostingId.Equals(jobId));
        }
    }
}
