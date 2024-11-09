﻿using Candidate_BusinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class JobPostingRepository : IJobPostingRepository
    {
        public List<JobPosting> GetJobPostings() => JobPostDAO.Instance.GetJobPostings();

        public JobPosting GetJobPosting(string jobId) => JobPostDAO.Instance.GetJobPosting(jobId);

    }
}
