﻿using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public interface IJobPostingRepository
    {
        public List<JobPosting> GetJobPostings();
        public JobPosting GetJobPosting(string jobId);
    }
}
