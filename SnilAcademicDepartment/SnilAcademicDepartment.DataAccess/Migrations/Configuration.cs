using System.Data.Entity.Migrations;
using System.IO;
using SnilAcademicDepartment.DataAccess.DBTypesInitialisation;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SnilAcademicDepartment.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SnilDBContext>
    {
        
        private PageType[] _pageTypes;

        private Language[] _languages;

        private List<EducationBlock> _educationBlocks = new List<EducationBlock>();

        private List<Seminar> _seminars = new List<Seminar>();

        private List<Lecture> _lectures = new List<Lecture>();

        private List<Project> _projects = new List<Project>();

        private Document _document;

        private Biography _biography;

        private Image _image;

        private static string _imgPath = @"D:\GitHub_projects\SNIL\SNIL-Department-of-BSU\SnilAcademicDepartment\SnilAcademicDepartment.DataAccess\img\BSU3.jpg"; // D:\Visual Studio Projects\SNIL\SnilAcademicDepartment\SnilAcademicDepartment.DataAccess\img\BSU3.jpg
        private byte[] _imgByte = File.ReadAllBytes(_imgPath);

        private static string _docPath = @"D:\GitHub_projects\SNIL\SNIL-Department-of-BSU\SnilAcademicDepartment\SnilAcademicDepartment.DataAccess\img\�������  - ���.docx"; // D:\Visual Studio Projects\SNIL\SnilAcademicDepartment\SnilAcademicDepartment.DataAccess\img\�������  - ���.docx
        private byte[] _docByte = File.ReadAllBytes(_docPath);

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SnilAcademicDepartment.DataAccess.SnilDBContext context)
        {
            using (var db = new SnilDBContext())
            {
                // Add page types.
                PageTypeDBInit.DBInit(db, out this._pageTypes);

                // Add languages.
                LanguageDBInit.DBInit(db, out this._languages);

                // Add image.
                ImageDBInit.DBInit(db, this._imgByte, _imgPath, out this._image);

                // Add Document.
                DocumentDBInit.DBInit(db, this._docByte, _docPath, out this._document);

                // Add Biography.
                BiographyDBInit.DBInit(db, "MyBio", out this._biography);

                // Add Education blocks.
                EducationKeyAreaDBInit.DBInit(db, "Seminar", "RU", 1, this._image, this._languages[0], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "ENSeminar", "EN", 1, this._image, this._languages[1], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "DESeminar", "DE", 1, this._image, this._languages[2], this._educationBlocks);

                EducationKeyAreaDBInit.DBInit(db, "Lection", "RU", 2, this._image, this._languages[0], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "ENLection", "EN", 2, this._image, this._languages[1], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "DELection", "DE", 2, this._image, this._languages[2], this._educationBlocks);

                EducationKeyAreaDBInit.DBInit(db, "QuickLearning", "RU", 3, this._image, this._languages[0], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "ENQuickLearning", "EN", 3, this._image, this._languages[1], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "DEQuickLearning", "DE", 3, this._image, this._languages[2], this._educationBlocks);

                // Add EducationTopics.
                EducationTopicsSeminar(db);
                EducationLectureTopics(db);
                EducationQuickLerningTopics(db);

                // Init History page preview data.
                PreviewDBInit.DBInit(db, "�������", "RU", this._pageTypes[4], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "History", "EN", this._pageTypes[4], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "�������DE", "DE", this._pageTypes[4], this._languages[2], this._imgByte);

                // Init People page preview data.
                PreviewDBInit.DBInit(db, "��������", "RU", this._pageTypes[3], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "People", "EN", this._pageTypes[3], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "��������DE", "DE", this._pageTypes[3], this._languages[2], this._imgByte);

                // Init Projects page preview data.
                PreviewDBInit.DBInit(db, "�������", "RU", this._pageTypes[1], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "Projects", "EN", this._pageTypes[1], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "�������DE", "DE", this._pageTypes[1], this._languages[2], this._imgByte);

                // Init Education page preview data.
                PreviewDBInit.DBInit(db, "��������", "RU", this._pageTypes[0], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "Education", "EN", this._pageTypes[0], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "��������DE", "DE", this._pageTypes[0], this._languages[2], this._imgByte);

                // Init Home page preview data.
                PreviewDBInit.DBInit(db, "���Projects", "RUProjects", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "HomeProjects", "ENProjects", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "���DEProjects", "DEProjects", this._pageTypes[2], this._languages[2], this._imgByte, true);

                PreviewDBInit.DBInit(db, "���Education", "RUEducation", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "HomeEducation", "ENEducation", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "���DEEducation", "DEEducation", this._pageTypes[2], this._languages[2], this._imgByte, true);

                PreviewDBInit.DBInit(db, "���People", "RUPeople", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "HomePeople", "ENPeople", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "���DEPeople", "DEPeople", this._pageTypes[2], this._languages[2], this._imgByte, true);

                PreviewDBInit.DBInit(db, "���History", "RUHistory", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "HomeHistory", "ENHistory", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "���DEHistory", "DEHistory", this._pageTypes[2], this._languages[2], this._imgByte, true);

                PreviewDBInit.DBInit(db, "���Projects", "RUProjects", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "HomeProjects", "ENProjects", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "���DEProjects", "DEProjects", this._pageTypes[2], this._languages[2], this._imgByte, true);


                // Init Projects in database.
                AddingProjects(db);

                // Init Seminars in database.
                AddingSeminars(db);

                // Init Lectures in database.
                AddingLectures(db);

                // Init Lectures in database.
                AddingPersons(db);
            }
        }

        private void AddingPersons(SnilDBContext db)
        {
            for (int i = 1; i < 6; i++)
            {
                PersonDBInit.DBInit(db, $"Name{i}", $"SecoundName1{i}", $"FathersName{i}", this._biography, this._image, "AcademicTitle", "Degree", this._languages[0], "Status", "�����", this._lectures, this._seminars, this._projects);
                PersonDBInit.DBInit(db, $"Name{i}", $"SecoundName2{i}", $"FathersName{i}", this._biography, this._image, "AcademicTitle", "Degree", this._languages[1], "Status", "�����", this._lectures, this._seminars, this._projects);
                PersonDBInit.DBInit(db, $"Name{i}", $"SecoundName3{i}", $"FathersName{i}", this._biography, this._image, "AcademicTitle", "Degree", this._languages[2], "Status", "�����", this._lectures, this._seminars, this._projects);
            }
        }

        private void AddingLectures(SnilDBContext db)
        {
            for (int i = 1; i < 13; i++)
            {
                LecturesDBInit.DBInit(db, $"LectureName{i}", this._languages[0], this._lectures, this._document);
                LecturesDBInit.DBInit(db, $"LectureName{i}", this._languages[1], this._lectures, this._document);
                LecturesDBInit.DBInit(db, $"LectureName{i}", this._languages[2], this._lectures, this._document);
            }
        }

        private void AddingSeminars(SnilDBContext db)
        {
            for (int i = 1; i < 10; i++)
            {
                SeminarsDBInit.DBInit(db, $"Title{i}", this._languages[0], this._document, this._seminars);
                SeminarsDBInit.DBInit(db, $"Title{i}", this._languages[1], this._document, this._seminars);
                SeminarsDBInit.DBInit(db, $"Title{i}", this._languages[2], this._document, this._seminars);
            }
        }

        private void AddingProjects(SnilDBContext db)
        {
            var commId = 11;
            ProjectsDBInit.DBInit(db, commId, "P111", "RU", "New", DateTime.UtcNow, this._languages[0], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P112", "EN", "New", DateTime.UtcNow, this._languages[1], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P113", "DE", "New", DateTime.UtcNow, this._languages[2], this._image, this._document, this._projects);
            commId = 12;
            ProjectsDBInit.DBInit(db, commId, "P121", "RU", "New", DateTime.UtcNow, this._languages[0], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P122", "EN", "New", DateTime.UtcNow, this._languages[1], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P123", "DE", "New", DateTime.UtcNow, this._languages[2], this._image, this._document, this._projects);
            commId = 13;
            ProjectsDBInit.DBInit(db, commId, "P131", "RU", "New", DateTime.UtcNow, this._languages[0], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P132", "EN", "New", DateTime.UtcNow, this._languages[1], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P133", "DE", "New", DateTime.UtcNow, this._languages[2], this._image, this._document, this._projects);

            commId = 21;
            ProjectsDBInit.DBInit(db, commId, "P211", "RU", "Current", DateTime.UtcNow, this._languages[0], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P212", "EN", "Current", DateTime.UtcNow, this._languages[1], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P213", "DE", "Current", DateTime.UtcNow, this._languages[2], this._image, this._document, this._projects);
            commId = 22;
            ProjectsDBInit.DBInit(db, commId, "P21", "RU", "Current", DateTime.UtcNow, this._languages[0], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P22", "EN", "Current", DateTime.UtcNow, this._languages[1], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P23", "DE", "Current", DateTime.UtcNow, this._languages[2], this._image, this._document, this._projects);
            commId = 23;
            ProjectsDBInit.DBInit(db, commId, "P31", "RU", "Current", DateTime.UtcNow, this._languages[0], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P22", "EN", "Current", DateTime.UtcNow, this._languages[1], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P23", "DE", "Current", DateTime.UtcNow, this._languages[2], this._image, this._document, this._projects);

            commId = 31;
            ProjectsDBInit.DBInit(db, commId, "P311", "RU", "Finished", DateTime.UtcNow, this._languages[0], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P312", "EN", "Finished", DateTime.UtcNow, this._languages[1], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P313", "DE", "Finished", DateTime.UtcNow, this._languages[2], this._image, this._document, this._projects);
            commId = 32;
            ProjectsDBInit.DBInit(db, commId, "P321", "RU", "Finished", DateTime.UtcNow, this._languages[0], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P322", "EN", "Finished", DateTime.UtcNow, this._languages[1], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P323", "DE", "Finished", DateTime.UtcNow, this._languages[2], this._image, this._document, this._projects);
            commId = 33;
            ProjectsDBInit.DBInit(db, commId, "P331", "RU", "Finished", DateTime.UtcNow, this._languages[0], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P332", "EN", "Finished", DateTime.UtcNow, this._languages[1], this._image, this._document, this._projects);
            ProjectsDBInit.DBInit(db, commId, "P333", "DE", "Finished", DateTime.UtcNow, this._languages[2], this._image, this._document, this._projects);

        }

        private void EducationQuickLerningTopics(SnilDBContext db)
        {
            EducationTopicDBInit.DBInit(db, "RUComputer Information Technologies", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUData Mining", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUQuantum Systems Modeling", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUDatabases", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUNeural Networks", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUProgramming of Microprocessor Systems", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUObject-Oriented Technologies", this._educationBlocks[6]);
            //
            EducationTopicDBInit.DBInit(db, "ENComputer Information Technologies", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENData Mining", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENQuantum Systems Modeling", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENDatabases", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENNeural Networks", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENProgramming of Microprocessor Systems", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENObject-Oriented Technologies", this._educationBlocks[7]);
            //
            EducationTopicDBInit.DBInit(db, "DEComputer Information Technologies", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEData Mining", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEQuantum Systems Modeling", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEDatabases", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DENeural Networks", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEProgramming of Microprocessor Systems", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEObject-Oriented Technologies", this._educationBlocks[8]);
        }

        private void EducationLectureTopics(SnilDBContext db)
        {
            EducationTopicDBInit.DBInit(db, "RUMathematical Modeling", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUSimulation and Statistical Modeling.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUTheory of Probability and Mathematical Statistics.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RURandom Processes.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUStochastic Systems.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUBasics of Systems Theory.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUInformation-Measuring Systems.", this._educationBlocks[3]);
            //
            EducationTopicDBInit.DBInit(db, "ENMathematical Modeling", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENSimulation and Statistical Modeling.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENTheory of Probability and Mathematical Statistics.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENRandom Processes.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENStochastic Systems.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENBasics of Systems Theory.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENInformation-Measuring Systems.", this._educationBlocks[4]);
            //
            EducationTopicDBInit.DBInit(db, "DEMathematical Modeling", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DESimulation and Statistical Modeling.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DETheory of Probability and Mathematical Statistics.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DERandom Processes.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DEStochastic Systems.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DEBasics of Systems Theory.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DEInformation-Measuring Systems.", this._educationBlocks[5]);
        }

        private void EducationTopicsSeminar(SnilDBContext db)
        {
            EducationTopicDBInit.DBInit(db, "RUGene Expression of Secondary Messengers and Replicates", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUGenomic and Molecular Genetic Directions in the Area of Infectology", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUSoftware GeneExpressionAnalyser for analysis of DNA microarrays", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUAnalysis of DNA microarrays", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUDigital processing biology images", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUSoftware CellDataMiner for Analysis of Luminescence Images of Cancer Cells", this._educationBlocks[0]);
            //
            EducationTopicDBInit.DBInit(db, "ENGene Expression of Secondary Messengers and Replicates", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENGenomic and Molecular Genetic Directions in the Area of Infectology", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENSoftware GeneExpressionAnalyser for analysis of DNA microarrays", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENAnalysis of DNA microarrays", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENDigital processing biology images", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENSoftware CellDataMiner for Analysis of Luminescence Images of Cancer Cells", this._educationBlocks[1]);
            //
            EducationTopicDBInit.DBInit(db, "DEGene Expression of Secondary Messengers and Replicates", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DEGenomic and Molecular Genetic Directions in the Area of Infectology", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DESoftware GeneExpressionAnalyser for analysis of DNA microarrays", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DEAnalysis of DNA microarrays", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DEDigital processing biology images", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DESoftware CellDataMiner for Analysis of Luminescence Images of Cancer Cells", this._educationBlocks[2]);
        }
    }
}
