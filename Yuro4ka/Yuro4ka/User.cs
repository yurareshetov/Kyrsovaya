//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yuro4ka
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.UserDocument = new HashSet<UserDocument>();
            this.UserService = new HashSet<UserService>();
        }
    
        public int Id { get; set; }
        public string Login { get; set; }
        public Nullable<double> Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronomyc { get; set; }
        public string Emai { get; set; }
        public Nullable<System.DateTime> BirthName { get; set; }
        public int Rolld { get; set; }
        public string Photo { get; set; }
        public string WorkExperience { get; set; }
        public Nullable<double> Direction { get; set; }
        public Nullable<decimal> Salary { get; set; }
    
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserDocument> UserDocument { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserService> UserService { get; set; }
    }
}
