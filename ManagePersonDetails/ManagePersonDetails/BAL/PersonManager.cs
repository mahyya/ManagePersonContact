using ManagePersonDetails.DAL;
using ManagePersonDetails.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagePersonDetails.BAL
{
    public class PersonManager
    {

        public List<PersonReport> ListPerson(Criteria criteria)
        {
            List<PersonReport> listPerson = null;
            JObject result = null;
            PersonProvider provider = null;

            try
            {
                listPerson = new List<PersonReport>();
                result = new JObject();
                provider = new PersonProvider();
                result = provider.ListPerson(criteria);
                if (result != null)
                {
                    listPerson = result["Person"].ToObject<List<PersonReport>>();
                }               
            }
            catch (Exception ex)
            {
                throw;
            }

            return listPerson;
        }

        public bool AddPerson(PersonReport personDetails)
        {
            PersonProvider provider = null;
            bool isAdded = false;

            try
            {
                provider = new PersonProvider();
                isAdded = provider.AddPerson(personDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
            return isAdded;
        }

        public bool UpdatePerson(PersonReport personDetails)
        {
            bool isUpdated = false;

            PersonProvider provider = null;

            try
            {
                provider = new PersonProvider();
                isUpdated = provider.UpdatePerson(personDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
            return isUpdated;
        }

        public bool UpdatePersonStatus(PersonReport personDetails)
        {
            bool isUpdated = false;

            PersonProvider provider = null;

            try
            {
                provider = new PersonProvider();
                isUpdated = provider.UpdatePersonStatus(personDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
            return isUpdated;
        }
    }
}