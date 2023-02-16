using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;

namespace OnlineStore.Data;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(

             new Category
             {
                 Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                 Name = "Badiy",
                 Description = "A book is a medium for recording information in the form of writing or images",
               //  ImageUrl = "https://media.istockphoto.com/photos/three-blue-and-red-books-picture-id139564474?k=20&m=139564474&s=612x612&w=0&h=lvALMCIeOTy581tT2jW9QDZXPCMCPltReaas6dHJQvE="
             }, new Category
             {
                 Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                 Name = "Ilmiy",
                 Description = "A book is a medium for recording information in the form of writing or images",
                 //ImageUrl = "https://media.istockphoto.com/photos/three-blue-and-red-books-picture-id139564474?k=20&m=139564474&s=612x612&w=0&h=lvALMCIeOTy581tT2jW9QDZXPCMCPltReaas6dHJQvE="
             },
             new Category
             {
                 Id= new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                 Name = "Tibbiyot",
                 Description = "A book is a medium for recording information in the form of writing or images",
                 //ImageUrl = "https://media.istockphoto.com/photos/three-blue-and-red-books-picture-id139564474?k=20&m=139564474&s=612x612&w=0&h=lvALMCIeOTy581tT2jW9QDZXPCMCPltReaas6dHJQvE="
             });
    }
}
