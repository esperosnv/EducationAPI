using Microsoft.EntityFrameworkCore;
using EducationAPI.Data.Entities; 

namespace EducationAPI.Data.Context.Seeder
{
    public static class EducationSeeder
    {
        public static void EducationSeedDatabase(this ModelBuilder builder)
        {
            List<MaterialType> materialTypes = new List<MaterialType>();
            int articleID = 1;
            int videoID = 2;
            int tutorialID = 3;
            int bookID = 4;

            MaterialType article = new MaterialType() { MaterialTypeID = articleID, Name = "Article", Definition = "A written work published in a print or electronic medium." };
            MaterialType video = new MaterialType() { MaterialTypeID = videoID, Name = "Video", Definition = "A video material that focuses mostly on guiding step-by-step in dedicated topic”)" };
            MaterialType tutorial = new MaterialType() { MaterialTypeID = tutorialID, Name = "Tutorial", Definition = "A written step-by-step guide." };
            MaterialType book = new MaterialType() { MaterialTypeID = bookID, Name = "Book", Definition = "A long educational work published in printed or electronic form." };
            materialTypes.Add(article);
            materialTypes.Add(video);
            materialTypes.Add(tutorial);
            materialTypes.Add(book);

            List<Author> authors = new List<Author>();

            int parkerID = 1;
            int remmerID = 2;
            int oscroftID = 3;
            int humphrysID = 4;
            int kruszelnickiID = 5;

            Author parker = new Author() { AuthorID = parkerID, Name = "Gabrila Parker", Description = "Professor at Jagiellonian University" };
            Author remmer = new Author() { AuthorID = remmerID, Name = "Herb Remmer", Description = "PhD at AGH"};
            Author oscroft = new Author() { AuthorID = oscroftID, Name = "Lira Oscroft", Description = "Master's at University of Warsaw" };
            Author humphrys = new Author() { AuthorID = humphrysID, Name = "Teador Humphrys", Description = "Engineer's at University of Wroclaw"};
            Author kruszelnicki = new Author() { AuthorID = kruszelnickiID, Name = "Konstantine Kruszelnicki", Description = "Student at Nicolaus Copernicus University" };
            
            authors.Add(parker);
            authors.Add(remmer);    
            authors.Add(kruszelnicki);
            authors.Add(oscroft);
            authors.Add(humphrys);

            List<Material> materials = new List<Material>();

            int lectusID = 1;
            int urnaID = 2;
            int liberoID = 3;
            int maurisID = 4;
            int sapienID = 5;
            int ametID = 6;
            int orciLuctusID = 7;
            int etiamID = 8;
            int nullaID = 9;
            int augueID = 10;

            Material lectus = new Material()
            {
                MaterialID = lectusID,
                Title = "LectusPellentesque.mov",
                Description = "Automated discrete Graphic Interface",
                Location = "icio.us",
                AuthorID = parkerID,
                MaterialTypeID =videoID,
                PublishingDate = new DateTime(2015, 12, 31)
            };
            Material urna = new Material()
            {
                MaterialID = urnaID,
                Title = "Urna.avi",
                Description = "Inverse solution-oriented flexibility",
                Location = "4shared.com",
                AuthorID = humphrysID,
                MaterialTypeID = videoID,
                PublishingDate = new DateTime(2011, 11, 14)
            };
            Material libero = new Material()
            {
                MaterialID = liberoID,
                Title = "Libero.ppt",
                Description = "Synchronised asynchronous process improvement",
                Location = "1und1.de",
                AuthorID = kruszelnickiID,
                MaterialTypeID = tutorialID,
                PublishingDate = new DateTime(2022, 02, 01)
            };
            Material mauris = new Material()
            {
                MaterialID = maurisID,
                Title = "MaurisEnim.ppt",
                Description = "Virtual 24 hour migration",
                Location = "flavors.me",
                AuthorID = kruszelnickiID,
                MaterialTypeID = tutorialID,
                PublishingDate = new DateTime(2005, 10, 01)
            };
            Material sapien = new Material()
            {
                MaterialID = sapienID,
                Title = "Sapien.txt",
                Description = "Customer-focused bifurcated core",
                Location = "pinterest.com",
                AuthorID = remmerID,
                MaterialTypeID = articleID,
                PublishingDate = new DateTime(2017, 07, 25)
            };
            Material amet = new Material()
            {
                MaterialID = ametID,
                Title = "AmetCursus.pdf",
                Description = "Reverse-engineered empowering frame",
                Location = "scientificamerican.com",
                AuthorID = oscroftID,
                MaterialTypeID = bookID,
                PublishingDate = new DateTime(1999, 04, 12)
            };
            Material orciLuctus = new Material()
            {
                MaterialID = orciLuctusID,
                Title = "OrciLuctus.txt",
                Description = "Balanced tangible toolset",
                Location = "typepad.com",
                AuthorID = humphrysID,
                MaterialTypeID = articleID,
                PublishingDate = new DateTime(2002, 09, 16)
            };
            Material etiam = new Material()
            {
                MaterialID = etiamID,
                Title = "EtiamJusto.avi",
                Description = "Devolved eco-centric array",
                Location = "hexun.com",
                AuthorID = kruszelnickiID,
                MaterialTypeID = videoID,
                PublishingDate = new DateTime(2021, 03, 10)
            };

            Material nulla = new Material()
            {
                MaterialID = nullaID,
                Title = "NullaIntegerPede.pdf",
                Description = "Synchronised 24 hour moratorium",
                Location = "csmonitor.com",
                AuthorID = oscroftID,
                MaterialTypeID = bookID,
                PublishingDate = new DateTime(2000, 11, 22)
            };

            Material augue = new Material()
            {
                MaterialID = augueID,
                Title = "Augue.txt",
                Description = "Realigned 3rd generation groupware",
                Location = "ucoz.com",
                AuthorID = remmerID,
                MaterialTypeID = articleID,
                PublishingDate = new DateTime(2017, 01, 01)
            };

            materials.Add(etiam);
            materials.Add(nulla);   
            materials.Add(augue);   
            materials.Add(lectus);
            materials.Add(urna);
            materials.Add(libero);
            materials.Add(mauris);
            materials.Add(sapien);
            materials.Add(amet);
            materials.Add(orciLuctus);



            List<Review> reviews = new List<Review>();

            Review a1 = new Review() { ReviewID = 1, Text = "Aenean lectus.", MaterialID = lectusID, Rating = 6 };
            Review b1 = new Review() { ReviewID = 2, Text = "In blandit ultrices enim.", MaterialID = lectusID, Rating = 7 };
            Review c1 = new Review() { ReviewID = 3, Text = "Aliquam sit amet diam in magna bibendum imperdiet.", MaterialID = urnaID, Rating = 5 };
            Review d1 = new Review() { ReviewID = 4, Text = "Integer ac leo.", MaterialID = urnaID, Rating = 4 };
            Review e1 = new Review() { ReviewID = 5, Text = "Maecenas pulvinar lobortis est.", MaterialID = liberoID, Rating = 5 };
            Review f1 = new Review() { ReviewID = 6, Text = "Nulla mollis molestie lorem.", MaterialID = liberoID, Rating = 6 };
            Review g1 = new Review() { ReviewID = 7, Text = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae", MaterialID = maurisID, Rating = 7 };
            Review h1 = new Review() { ReviewID = 8, Text = "Phasellus id sapien in sapien iaculis congue.", MaterialID = maurisID, Rating = 8 };
            Review q1 = new Review() { ReviewID = 9, Text = "Nunc rhoncus dui vel sem.", MaterialID = ametID, Rating = 9 };
            Review w1 = new Review() { ReviewID = 10, Text = "Vestibulum quam sapien, varius ut, blandit non, interdum in, ante.", MaterialID = ametID, Rating = 10 };
            Review r1 = new Review() { ReviewID = 11, Text = "Aenean lectus.", MaterialID = orciLuctusID, Rating = 7 };
            Review t1 = new Review() { ReviewID = 12, Text = "Nulla tempus.", MaterialID = orciLuctusID, Rating = 6 };
            Review y1 = new Review() { ReviewID = 13, Text = "Praesent lectus.", MaterialID = etiamID, Rating = 4 };
            Review u1 = new Review() { ReviewID = 14, Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.", MaterialID = etiamID, Rating = 5 };
            Review i1 = new Review() { ReviewID = 15, Text = "In quis justo.", MaterialID = sapienID, Rating = 6 };
            Review o1 = new Review() { ReviewID = 16, Text = "Phasellus id sapien in sapien iaculis congue.", MaterialID = sapienID, Rating = 7 };
            Review p1 = new Review() { ReviewID = 17, Text = "Duis at velit eu est congue elementum.", MaterialID = nullaID, Rating = 8 };
            Review s1 = new Review() { ReviewID = 18, Text = "Cras pellentesque volutpat dui.", MaterialID = nullaID, Rating = 9 };
            Review j1 = new Review() { ReviewID = 19, Text = "Maecenas tincidunt lacus at velit.", MaterialID = augueID, Rating = 10 };
            Review k1 = new Review() { ReviewID = 20, Text = "In quis justo.", MaterialID = augueID, Rating = 8 };

            reviews.Add(u1);
            reviews.Add(o1);
            reviews.Add(p1);
            reviews.Add(s1);
            reviews.Add(j1);
            reviews.Add(k1);
            reviews.Add(a1);
            reviews.Add(b1);
            reviews.Add(c1);
            reviews.Add(d1);
            reviews.Add(e1);
            reviews.Add(f1);
            reviews.Add(g1);
            reviews.Add(h1);
            reviews.Add(i1);
            reviews.Add(q1);
            reviews.Add(y1);
            reviews.Add(t1);
            reviews.Add(r1);
            reviews.Add(w1);

            builder.Entity<Author>().HasData(authors);
            builder.Entity<Material>().HasData(materials);
            builder.Entity<MaterialType>().HasData(materialTypes);
            builder.Entity<Review>().HasData(reviews);
        }







    }
}
