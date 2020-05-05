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

			context.ProductGroups.AddRange(myProductGroups);

			base.Seed(context);
		}

	}
}
