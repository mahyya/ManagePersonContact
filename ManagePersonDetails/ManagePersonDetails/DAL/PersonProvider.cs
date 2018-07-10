using ManagePersonDetails.Models;
using ManagePersonDetails.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagePersonDetails.DAL
{
    public class PersonProvider
    {

        #region GetListPerson

        public JObject ListPerson(Criteria criteria)
        {
            JObject listPerson = null;

            try
            {
                listPerson = new JObject();

                using (EVO_PersonDBEntities context = new EVO_PersonDBEntities())
                {
                    var list = (from P in context.Person
                                join C in context.PersonContacts on P.ID equals C.PersonID
                                where ((criteria.PersonID ==0) || (criteria.PersonID >0 && P.ID==criteria.PersonID))
                                //where ((Helper.IsNullOrEmpty(criteria.EmailAddress) == true) || (C.EmailAddress.Contains(criteria.EmailAddress)))
                                //where ((Helper.IsNullOrEmpty(criteria.PhoneNumber) == true) || (C.PrimaryContactNo.Contains(criteria.PhoneNumber)))
                                //where ((Helper.IsNullOrEmpty(Convert.ToString(criteria.Status)) == true) || (P.IsActive == criteria.Status))
                                select new
                                {
                                    PersonID = P.ID,
                                    FirstName = P.FirstName,
                                    LastName = P.LastName,
                                    Gender = P.Gender,
                                 //   DateOfBirth = P.DateOfBirth,
                                    EmailAddress = C.EmailAddress,
                                    PhoneNumber = C.PrimaryContactNo,
                                    IsActive = P.IsActive
                                }).ToList();

                    listPerson.Add("Person", JArray.FromObject(list));
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return listPerson;
        }

        #endregion

        #region AddPersonDetails

        public bool AddPerson(PersonReport personDetails)
        {
            bool isAdded = false;
            Person person = null;
            PersonContact personContact = null;
            try
            {
                using (EVO_PersonDBEntities context = new EVO_PersonDBEntities())
                {
                    person = new Person();

                    person.FirstName = personDetails.FirstName;
                    person.LastName = personDetails.LastName;
                    person.Gender = personDetails.Gender;
             //       person.DateOfBirth = personDetails.DateOfBirth;
                    person.IsActive = personDetails.IsActive;
                    person.CreatedBy = 0;
                    person.ModifiedBy = 0;
                    person.CreatedDate = DateTime.UtcNow;
                    person.ModifiedDate = DateTime.UtcNow; 

                    context.Person.Add(person);
                    context.SaveChanges();

                    personContact = new PersonContact();


                    personContact.PersonID = person.ID;
                    personContact.EmailAddress= personDetails.EmailAddress;
                    personContact.PrimaryContactNo = personDetails.PhoneNumber;
                    AddPersonContact(personContact);
                    
                    isAdded = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return isAdded;
        }

        public bool AddPersonContact(PersonContact contactDetails)
        {
            bool isAdded = false;
            PersonContact personContact = null;
            try
            {
                using (EVO_PersonDBEntities context = new EVO_PersonDBEntities())
                {
                    personContact = new PersonContact();

                    personContact.PersonID = contactDetails.PersonID;
                    personContact.EmailAddress = contactDetails.EmailAddress;
                    personContact.PrimaryContactNo = contactDetails.PrimaryContactNo;
                    personContact.CreatedBy = 0;
                    personContact.ModifiedBy = 0;
                    personContact.CreatedDate = DateTime.UtcNow;
                    personContact.ModifiedDate = DateTime.UtcNow;
                    context.PersonContacts.Add(personContact);
                    context.SaveChanges();
                    isAdded = true;                  
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return isAdded;
        }

        #endregion

        #region UpdatePersonDetails

        public bool UpdatePerson(PersonReport personDetails)
        {
            bool isUpdated = false;
            PersonContact personContact = null;

            try
            {
                using (EVO_PersonDBEntities context = new EVO_PersonDBEntities())
                {
                    Person person= (from P in context.Person
                                 where P.ID == personDetails.PersonID
                                 select P).FirstOrDefault();

                    if (person != null)
                    {
                        person.FirstName = personDetails.FirstName;
                        person.LastName = personDetails.LastName;
                        person.Gender = personDetails.Gender;
                      //  person.DateOfBirth = personDetails.DateOfBirth;
                        personDetails.IsActive = personDetails.IsActive;

                        context.SaveChanges();

                        personContact = new PersonContact();


                        personContact.PersonID = person.ID;
                        personContact.EmailAddress = personDetails.EmailAddress;
                        personContact.PrimaryContactNo = personDetails.PhoneNumber;

                        UpdatePersonContact(personContact);
                           

                        isUpdated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return isUpdated;
        }

        public bool UpdatePersonContact(PersonContact contact)
        {
            bool isUpdated = false;

            try
            {
                using (EVO_PersonDBEntities context = new EVO_PersonDBEntities())
                {
                    PersonContact personContact = (from PC in context.PersonContacts
                                     where PC.PersonID == contact.PersonID
                                     select PC).FirstOrDefault();

                    if (personContact != null)
                    {
                        personContact.EmailAddress = contact.EmailAddress;
                        personContact.PrimaryContactNo = contact.PrimaryContactNo;
                        context.SaveChanges();
                        isUpdated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return isUpdated;
        }

        #endregion

        #region UpdatePersonStatus

        public bool UpdatePersonStatus(PersonReport personDetails)
        {
            bool isUpdated = false;

            try
            {
                using (EVO_PersonDBEntities context = new EVO_PersonDBEntities())
                {
                    Person person = (from P in context.Person
                                     where P.ID == personDetails.PersonID
                                     select P).FirstOrDefault();
                    if (person != null)
                    {
                        person.IsActive = personDetails.IsActive;
                        context.SaveChanges();
                        isUpdated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return isUpdated;
        }

        #endregion
    }
}