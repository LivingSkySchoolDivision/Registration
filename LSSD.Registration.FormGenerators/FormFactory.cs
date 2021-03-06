using System;
using System.Collections.Generic;
using System.IO;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;
using LSSD.Registration.FormGenerators.FormGenerators;
using System.Text.RegularExpressions;

namespace LSSD.Registration.FormGenerators 
{
    public class FormFactory : IDisposable
    {
        List<string> _generatedFileNames = new List<string>();
        string _tempDirPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        public FormFactory(string TempFolderPath) {
            this._tempDirPath = TempFolderPath;
            createTempDirectory();
        }

        public FormFactory() {
            createTempDirectory();
        }

        void createTempDirectory() {
            if (!Directory.Exists(_tempDirPath)) {
                Directory.CreateDirectory(_tempDirPath);
            }
            Console.WriteLine("Temp directory is: " + _tempDirPath);
        }

        // TODO: Improve resuablility of the following two methods
        public string GenerateForm(SubmittedPreKApplicationForm Form, TimeZoneInfo TimeZone)
        {
            if (Form == null) {
                throw new Exception("Form cannot be null");
            }

            string filename = Path.Combine(_tempDirPath, genFilename(Form));
                       
            PreKApplicationFormGenerator generator = new PreKApplicationFormGenerator();

            // Generate the file
            generator.Generate(Form, TimeZone, filename);

            // Store the filename in the tracking list
            _generatedFileNames.Add(filename);
            
            // Return the filename
            return filename;
        }

        public string GenerateForm(SubmittedGeneralRegistrationForm Form, TimeZoneInfo TimeZone)
        {
            if (Form == null) {
                throw new Exception("Form cannot be null");
            }

            string filename = Path.Combine(_tempDirPath, genFilename(Form));
                       
            GeneralRegistrationFormGenerator generator = new GeneralRegistrationFormGenerator();

            // Generate the file
            generator.Generate(Form, TimeZone, filename);

            // Store the filename in the tracking list
            _generatedFileNames.Add(filename);
            
            // Return the filename
            return filename;
        }

        private string genFilename(ISubmittedForm form) {
            return $"{form.Id.ToString()}.docx";
        }

        public void DeleteTempFiles() {
            List<string> deletedFiles = new List<string>();

            foreach(string filename in _generatedFileNames) {
                //try {
                    File.Delete(filename);
                    deletedFiles.Add(filename);
                //} catch {}
            }

            foreach(string filename in deletedFiles) {
                _generatedFileNames.Remove(filename);
            }
        }

        public void Dispose()
        {
            this.DeleteTempFiles();

            if (Directory.Exists(_tempDirPath)) {
                Directory.Delete(_tempDirPath);
            }
        }

        public static string SanitizeFilename(string input) {
            return Regex.Replace(input, "[^A-Za-z0-9-]", ""); 
        }
    }
}