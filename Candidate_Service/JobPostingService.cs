using Candidate_BusinessObjects;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class JobPostingService : IJobPostingService
    {
        private IJobPostingRepository iJobPostingRepo;
        public JobPostingService(IJobPostingRepository jobPostingRepository)
        {
            iJobPostingRepo = jobPostingRepository;
        }

        public List<JobPosting> GetJobPostings()
        {
            return iJobPostingRepo.GetJobPostings();
        }

        public JobPosting GetJobPosting(string jobId)
        {
            return iJobPostingRepo.GetJobPosting(jobId);
        }

    }
}
