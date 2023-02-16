using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;

namespace OnlineStore.Data;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
       /* builder.HasData(

            new Book
            {
                Id= new Guid("021ca3c1-0deb-4afd-ae94-2159a8472001"),
                Name = "Madaniyat va Ma'rifat",
                CategoryId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                ImageUrl = "https://media.istockphoto.com/photos/three-blue-and-red-books-picture-id139564474?k=20&m=139564474&s=612x612&w=0&h=lvALMCIeOTy581tT2jW9QDZXPCMCPltReaas6dHJQvE=",
                InStock = 20,
                IsPreferedFood = false,
                ShortDescription = "There must be literally hundreds of Albert Einstein books",
                LongDescription = "There must be literally hundreds of Albert Einstein books",
                Price = 4.5M
            },
            new Book
            {
                Id= new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                Name = "Oq qush",
                CategoryId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                ImageUrl = "https://media.istockphoto.com/photos/three-blue-and-red-books-picture-id139564474?k=20&m=139564474&s=612x612&w=0&h=lvALMCIeOTy581tT2jW9QDZXPCMCPltReaas6dHJQvE=",
                InStock = 20,
                IsPreferedFood = true,
                ShortDescription = "There must be literally hundreds of Albert Einstein books",
                LongDescription = "There must be literally hundreds of Albert Einstein books",
                Price = 5.3M
            },
            new Book
            {
                Id= new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                Name = "Broccoli",
                CategoryId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                ImageUrl = "https://media.istockphoto.com/photos/three-blue-and-red-books-picture-id139564474?k=20&m=139564474&s=612x612&w=0&h=lvALMCIeOTy581tT2jW9QDZXPCMCPltReaas6dHJQvE=",
                InStock = 20,
                IsPreferedFood = true,
                ShortDescription = "There must be literally hundreds of Albert Einstein books",
                LongDescription = "There must be literally hundreds of Albert Einstein books",
                Price = 3.3M
            });*/
    }
}
