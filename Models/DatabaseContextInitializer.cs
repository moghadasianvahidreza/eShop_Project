using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class DatabaseContextInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
	{
		protected override void Seed(DatabaseContext context)
		{
			IList<Role> myRoles = new List<Role>();

			myRoles.Add(new Role() { Id = 1, RoleTitle = "Admin", RoleName = "مدیریت سیستم" });
			myRoles.Add(new Role() { Id = 2, RoleTitle = "User", RoleName = "کاربر عادی" });

			context.Roles.AddRange(myRoles);

			// **************************************************
			// **************************************************

			IList<User> MyDefaultUser = new List<User>();

			MyDefaultUser.Add(new User() { Id = 1, RoleId = 1, Username = "Vahidreza", EmailAddress = "vrm.moghadasian@gmail.com", Password = "1234", ActiveCode = System.Guid.NewGuid().ToString(), IsActive = true, RegisterDate = System.DateTime.Now });
			MyDefaultUser.Add(new User() { Id = 2, RoleId = 2, Username = "Farzaneh", EmailAddress = "farzaneh@gmail.com", Password = "1234", ActiveCode = System.Guid.NewGuid().ToString(), IsActive = false, RegisterDate = System.DateTime.Now });

			context.Users.AddRange(MyDefaultUser);

			// **************************************************
			// **************************************************

			IList<ProductGroup> myProductGroups = new List<ProductGroup>();

			myProductGroups.Add(new ProductGroup() { GroupId = 1, GroupTitle = "لوازم صوتی و تصویری", ParentId = null });
			myProductGroups.Add(new ProductGroup() { GroupId = 2, GroupTitle = "تلویزیون", ParentId = 1 });
			myProductGroups.Add(new ProductGroup() { GroupId = 3, GroupTitle = "ضبط صوت", ParentId = 1 });
			myProductGroups.Add(new ProductGroup() { GroupId = 4, GroupTitle = "لوازم خانگی", ParentId = null });
			myProductGroups.Add(new ProductGroup() { GroupId = 5, GroupTitle = "یخچال", ParentId = 4 });
			myProductGroups.Add(new ProductGroup() { GroupId = 6, GroupTitle = "ماشین لباس شوئی", ParentId = 4 });
			myProductGroups.Add(new ProductGroup() { GroupId = 7, GroupTitle = "لوازم شخصی", ParentId = null });
			myProductGroups.Add(new ProductGroup() { GroupId = 8, GroupTitle = "تلفن همراه", ParentId = 7 });
			myProductGroups.Add(new ProductGroup() { GroupId = 9, GroupTitle = "عینک", ParentId = 7 });
			myProductGroups.Add(new ProductGroup() { GroupId = 10, GroupTitle = "لوازم ورزشی", ParentId = null });
			myProductGroups.Add(new ProductGroup() { GroupId = 11, GroupTitle = "پیراهن ورزشی", ParentId = 10 });
			myProductGroups.Add(new ProductGroup() { GroupId = 12, GroupTitle = "کلاه ورزشی", ParentId = 10 });
			myProductGroups.Add(new ProductGroup() { GroupId = 13, GroupTitle = "لوازم آشپزی", ParentId = null });
			myProductGroups.Add(new ProductGroup() { GroupId = 14, GroupTitle = "لوازم کیک پزی", ParentId = 13 });


			context.ProductGroups.AddRange(myProductGroups);

			// **************************************************
			// **************************************************

			IList<Feature> myFeatures = new List<Feature>();

			myFeatures.Add(new Feature() { FeatureId = 1, Title = "وزن" });
			myFeatures.Add(new Feature() { FeatureId = 2, Title = "رنگ" });
			myFeatures.Add(new Feature() { FeatureId = 3, Title = "ابعاد" });
			myFeatures.Add(new Feature() { FeatureId = 4, Title = "بلوتوث" });

			context.Features.AddRange(myFeatures);

			// **************************************************
			// **************************************************

			IList<ProductFeature> myProductFeatures = new List<ProductFeature>();

			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 1, ProductId = 1, FeatureId = 1, Value = "۱ کیلو" });
			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 2, ProductId = 2, FeatureId = 1, Value = "۲ کیلو" });
			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 3, ProductId = 1, FeatureId = 2, Value = "سبز" });
			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 4, ProductId = 1, FeatureId = 2, Value = "قرمز" });
			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 5, ProductId = 1, FeatureId = 2, Value = "آبی" });
			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 6, ProductId = 1, FeatureId = 2, Value = "قرمز" });
			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 7, ProductId = 2, FeatureId = 2, Value = "آبی" });
			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 8, ProductId = 2, FeatureId = 2, Value = "سفید" });
			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 9, ProductId = 2, FeatureId = 3, Value = "۲ سانت در ۲ سانت" });
			myProductFeatures.Add(new ProductFeature() { ProductFeatureId = 10, ProductId = 1, FeatureId = 3, Value = "۱ متر مربع" });

			context.ProductFeatures.AddRange(myProductFeatures);

			// **************************************************
			// **************************************************

			IList<Product> myProducts = new List<Product>();

			myProducts.Add(new Product() { ProductId = 1, ProductTitle = "پیراهن بارسلونا", ShortDescription = "باشگاه بارسلونا یک پ نامدار در کشور اسپانیا می باشد که پیراهن این باشگاه بسیار زیبا و وزین می باشد و ... بیشتر", Text = "این باشگاه با نام باشگاه فوتبال بارسلونا در سال ۱۸۹۹ توسط عده‌ای سوئیسی، انگلیسی و اسپانیایی و به رهبری خوان گمپر تأسیس شد. بارسا به نوعی، نهادی برای ترویج فرهنگ کاتالان و کاتالانیسم است و از این رو عبارت «فراتر از یک باشگاه» (به کاتالانی: Més que un club) را به عنوان شعار خود انتخاب کرده‌است. سرود رسمی باشگاه، اثر جوزپ ماریا اسپ", Price = 15000, CreateDate = System.DateTime.Now, ImageName = "~/Images/ProductImages/1.png" });
			myProducts.Add(new Product() { ProductId = 2, ProductTitle = "کاپ کیک خوشمزه ", ShortDescription = "این کاپ کیکهای #خوشمزه و ریزه میزه رو ببینید 😍 چ، بچه های من عاشق #فینگرکیک های کوچیک بیرونی شدن، منم...بیشتر", Text = "ین کاپ کیکهای #خوشمزه و ریزه میزه رو د 😍 چند وقتیه، بچه های من عاشق #فینگرکیک های کوچیک بیرونی شدن، منم ین کاپ کیکهای #خوشمزه و ریزه میزه رو ببینید 😍 چند وقتیه، بچه های من عاشق #فینگرکیک های کوچیک بیرونی شدن، منم ین کاپ کیکهای #خوشمزه و ریزه میزه رو ببینید 😍 چند وقتیه، بچه های من عاشق #فینگرکیک های کوچیک بیرونی شدن، منم", Price = 20000, CreateDate = System.DateTime.Now, ImageName = "~/Images/ProductImages/11.jpg" });

			context.Products.AddRange(myProducts);

			// **************************************************
			// **************************************************

			IList<ProductGallery> myProductGalleries = new List<ProductGallery>();

			myProductGalleries.Add(new ProductGallery() { GalleryId = 2, ProductId = 1, Title = "تصویر شماره ۱", ImageName = "~/Images/ProductImages/3.jpg" });
			myProductGalleries.Add(new ProductGallery() { GalleryId = 3, ProductId = 1, Title = "تصویر شماره ۱", ImageName = "~/Images/ProductImages/4.jpg" });
			myProductGalleries.Add(new ProductGallery() { GalleryId = 4, ProductId = 2, Title = "تصویر شماره ۱", ImageName = "~/Images/ProductImages/12.jpg" });
			myProductGalleries.Add(new ProductGallery() { GalleryId = 5, ProductId = 2, Title = "تصویر شماره ۱", ImageName = "~/Images/ProductImages/13.jpg" });
			myProductGalleries.Add(new ProductGallery() { GalleryId = 6, ProductId = 2, Title = "تصویر شماره ۱", ImageName = "~/Images/ProductImages/14.jpg" });

			context.ProductGalleries.AddRange(myProductGalleries);

			// **************************************************
			// **************************************************
			IList<ProductSelectedGroup> myProductSelectedGroups = new List<ProductSelectedGroup>();

			myProductSelectedGroups.Add(new ProductSelectedGroup() { ProductSelectedGroupId = 1, GroupId = 11, ProductId = 1 });
			myProductSelectedGroups.Add(new ProductSelectedGroup() { ProductSelectedGroupId = 2, GroupId = 14, ProductId = 2 });

			context.ProductSelectedGroups.AddRange(myProductSelectedGroups);

			// **************************************************
			// **************************************************

			IList<ProductTag> myProductTags = new List<ProductTag>();

			myProductTags.Add(new ProductTag() { ProductTagId = 1, ProductId = 1, Tag = "پیراهن" });
			myProductTags.Add(new ProductTag() { ProductTagId = 2, ProductId = 1, Tag = "بارسلونا" });
			myProductTags.Add(new ProductTag() { ProductTagId = 3, ProductId = 1, Tag = "ارزان" });
			myProductTags.Add(new ProductTag() { ProductTagId = 4, ProductId = 1, Tag = "اصلی" });
			myProductTags.Add(new ProductTag() { ProductTagId = 5, ProductId = 2, Tag = "فینگر" });
			myProductTags.Add(new ProductTag() { ProductTagId = 6, ProductId = 2, Tag = "کیک" });
			myProductTags.Add(new ProductTag() { ProductTagId = 7, ProductId = 2, Tag = "شکلاتی" });
			myProductTags.Add(new ProductTag() { ProductTagId = 8, ProductId = 2, Tag = "خامهای" });

			context.ProductTags.AddRange(myProductTags);

			// **************************************************
			// **************************************************

			IList<ProductComment> myProductComments = new List<ProductComment>();

			myProductComments.Add(new ProductComment() { ProductCommentId = 1, Name = "Vahidreza Moghadasian", EmailAddress = "vrm.moghadasian@gmail.com", Comment = "سلام دوستان من این محصول رو به شما دوستان عزیزم پیشنهاد می کنیم", CreateDate = System.DateTime.Now, Website = "", ParentId = null, ProductId = 1 });
			myProductComments.Add(new ProductComment() { ProductCommentId = 2, Name = "Sara Moghadasian", EmailAddress = "sara@gmail.com", Comment = "سلام وحید رض جان امیدوارم که به سلامتی از این محصول استفاده کنی", CreateDate = System.DateTime.Now, Website = "", ParentId = 1, ProductId = 1 });
			myProductComments.Add(new ProductComment() { ProductCommentId = 3, Name = "Nafas Moghadasian", EmailAddress = "nafas@gmail.com", Comment = "سلام دوستان منم هم این محصول رو به دوستان خوبم پیشنهاد می کنم ما خانوادگی این محصول رو خریداری کردیم", CreateDate = System.DateTime.Now, Website = "", ParentId = null, ProductId = 1 });

			context.ProductComments.AddRange(myProductComments);

			// **************************************************
			// **************************************************

			base.Seed(context);
		}

	}
}
