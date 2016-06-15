using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pharmacy;
using System.Collections.Generic;
using System.Threading;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddDataToDataBase()
        {
            ProductDAO productDao = new ProductDAO();


            List<string> name = new List<string> { "Acetaminophen", "Adderall", "Alprazolam", "Amitriptyline", "Amlodipine", "Amoxicillin", "Ativan", "Atorvastatin", "Azithromycin", "Ciprofloxacin", "Citalopram", "Clindamycin", "Clonazepam", "Codeine", "Cyclobenzaprine", "Cymbalta", "Doxycycline", "Gabapentin", "Hydrochlorothiazide", "Ibuprofen", "Lexapro", "Lisinopril", "Loratadine", "Lorazepam", "Losartan", "Lyrica", "Meloxicam", "Metformin", "Metoprolol", "Naproxen", "Omeprazole", "Oxycodone", "Pantoprazole", "Prednisone", "Tramadol", "Trazodone", "Viagra", "Wellbutrin", "Xanax", "Zoloft" };
            List<string> description = new List<string> { "the gastrointestinal tract (digestive system)", "For the cardiovascular system", "the central nervous system", "pain (analgesic drugs)", "musculo-skeletal disorders", "the eye", "the ear, nose and oropharynx", "the respiratory system", "endocrine problems", "For the reproductive system or urinary system", "For contraception", "For obstetrics and gynecology", "For the skin", "For infections and infestations", "For the immune system", "For allergic disorders", "For nutrition", "For neoplastic disorders", "For diagnostics", "For euthanasia", "the gastrointestinal tract (digestive system)", "For the cardiovascular system", "the central nervous system", "pain (analgesic drugs)", "musculo-skeletal disorders", "the eye", "the ear, nose and oropharynx", "the respiratory system", "endocrine problems", "For the reproductive system or urinary system", "For contraception", "For obstetrics and gynecology", "For the skin", "For infections and infestations", "For the immune system", "For allergic disorders", "For nutrition", "For neoplastic disorders", "For diagnostics", "For euthanasia" };
            List<string> brand = new List<string> { "A & Z Pharmaceutical, Inc.", "A-S Medication Solutions, LLC", "AAIPharma", "Abbott Laboratories", "AbbVie Inc.", "Acadia Pharmaceuticals, Inc.", "Accord Healthcare Inc.", "Accredo Health Group, Inc.", "Acella Pharmaceuticals, LLC", "Acorda Therapeutics, Inc.", "Actavis Pharma, Inc.", "Actelion Pharmaceuticals US, Inc.", "Acura Pharmaceuticals, Inc.", "Acusphere, Inc.", "Adapt Pharma, Inc.", "Adeona Pharmaceuticals, Inc.,", "Adolor Corporation", "Advance Pharmaceuticals Inc.", "Advanced Life Sciences, Inc", "Advanced Pharmaceutical Services Inc", "A & Z Pharmaceutical, Inc.", "A-S Medication Solutions, LLC", "AAIPharma", "Abbott Laboratories", "AbbVie Inc.", "Acadia Pharmaceuticals, Inc.", "Accord Healthcare Inc.", "Accredo Health Group, Inc.", "Acella Pharmaceuticals, LLC", "Acorda Therapeutics, Inc.", "Actavis Pharma, Inc.", "Actelion Pharmaceuticals US, Inc.", "Acura Pharmaceuticals, Inc.", "Acusphere, Inc.", "Adapt Pharma, Inc.", "Adeona Pharmaceuticals, Inc.,", "Adolor Corporation", "Advance Pharmaceuticals Inc.", "Advanced Life Sciences, Inc", "Advanced Pharmaceutical Services Inc" };
            List<int> price = new List<int> { 50, 30, 70, 110, 190, 180, 30, 40, 90, 190, 80, 150, 100, 10, 130, 180, 130, 60, 190, 170, 170, 40, 140, 140, 170, 60, 80, 70, 60, 150, 120, 70, 190, 10, 20, 70, 150, 70, 70, 170 };
            List<int> rack = new List<int> { 2, 2, 12, 0, 5, 12, 0, 12, 2, 15, 1, 2, 2, 11, 11, 15, 9, 14, 4, 9, 5, 12, 13, 1, 5, 14, 13, 0, 11, 7, 10, 11, 4, 7, 3, 11, 8, 14, 14, 0 };
            List<string> code = new List<string> { "900a", "901b", "902c", "903d", "904e", "905f", "906g", "907h", "908i", "909j", "910k", "911l", "912m", "913n", "914o", "915p", "916q", "917r", "918s", "919t", "920u", "921v", "922w", "923x", "924y", "925z", "926a", "927b", "928c", "929d", "930e", "931f", "932g", "933h", "934i", "935j", "936k", "937l", "938m", "939n" };

            Console.WriteLine("-");


                Console.WriteLine("--");

                for (int i = 0; i < 40; i++)
                {
                    Console.WriteLine("---");
                    productDao.addProduct(new Product(0, code[i], name[i], brand[i], rack[i], price[i], description[i]));
                }




            //  Assert.AreEqual();
        }
    }
}
