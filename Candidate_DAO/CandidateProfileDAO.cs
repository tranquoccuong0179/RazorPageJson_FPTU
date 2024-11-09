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
    public class CandidateProfileDAO
    {
        private readonly string filePath = Path.Combine("Data", "CandidateProfile.json");
        private static CandidateProfileDAO instance;

        private List<CandidateProfile> ReadFromFile()
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<CandidateProfile>>(json) ?? new List<CandidateProfile>();
            }
            catch (Exception ex)
            {
                return new List<CandidateProfile>();
            }
        }
        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }

        public List<CandidateProfile> GetCandidateProfiles() => ReadFromFile();

        public List<CandidateProfile> GetCandidateByName(string fullName) 
        {
            var entity = ReadFromFile().Where(x => x.Fullname.ToLower().Contains(fullName.ToLower())).ToList();
            return entity;
        }
        public CandidateProfile? GetCandidate(string id)
        {
            var candidates = ReadFromFile() ?? new List<CandidateProfile>();
            var entity = ReadFromFile().SingleOrDefault(m => m.CandidateId.Equals(id));
            return entity;
        }

        public bool AddCandidateProfile(CandidateProfile newCandidateProfile)
        {
            bool result = false;
            if (newCandidateProfile == null || string.IsNullOrEmpty(newCandidateProfile.CandidateId))
                throw new ArgumentNullException(nameof(newCandidateProfile), "candidateProfileNew is null or CandidateId is empty");
            List<CandidateProfile> candidates = ReadFromFile();
            CandidateProfile? candidateProfile = GetCandidate(newCandidateProfile.CandidateId);
            try
            {
                if (candidateProfile == null)
                {
                    candidates.Add(newCandidateProfile);
                    WriteToFile(candidates);
                    result = true;
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            List<CandidateProfile> candidates = ReadFromFile();
            try
            {
                if (candidate != null)
                {
                    var index = candidates.FindIndex(c => c.CandidateId == candidateProfile.CandidateId);
                    if (index != -1)
                    {
                        candidates[index] = candidateProfile;
                        WriteToFile(candidates);
                        result = true;
                    }
                }
            } 
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            List<CandidateProfile> candidates = ReadFromFile();
            try
            {
                if (candidate != null)
                {
                    var index = candidates.FindIndex(c => c.CandidateId == candidateProfile.CandidateId);
                    if (index != -1)
                    {
                        candidates.RemoveAt(index);
                        WriteToFile(candidates);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        private void WriteToFile(List<CandidateProfile> candidates)
        {
            try
            {
                string json = JsonSerializer.Serialize(candidates, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
