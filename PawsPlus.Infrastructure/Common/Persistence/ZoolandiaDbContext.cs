using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Infrastructure.Identity;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Common.Persistence;

public class 
    ZoolandiaDbContext(DbContextOptions<ZoolandiaDbContext> options)
        : IdentityDbContext<User>(options)
{
    
    public DbSet<Profile> Profiles { get; set; } = default!;

    public DbSet<Pet> Pets { get; set; } = default!;

    public DbSet<Post> Posts { get; set; } = default!;
    
    public DbSet<Service> Services { get; set; } = default!;
    
    public DbSet<Breed> Breeds { get; set; } = default!;
    
    public DbSet<Booking> Bookings { get; set; } = default!;
    
    public DbSet<AnimalType> AnimalTypes { get; set; } = default!;
    
    public DbSet<MeetingPlace> MeetingPlaces { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        builder.ApplyConfigurationsFromAssembly(typeof(ZoolandiaDbContext).Assembly);

        SeedMeetingPlaces(builder.Entity<MeetingPlace>());
        SeedAnimalTypes(builder.Entity<AnimalType>());
        SeedBreeds(builder.Entity<Breed>());
        // SeedAdminAndRoles(builder);
        
        base.OnModelCreating(builder);
    }

    private void SeedMeetingPlaces(EntityTypeBuilder<MeetingPlace> entity)
    {
        entity.HasData(
            new MeetingPlace(1, "AtOwners"),
            new MeetingPlace(2, "AtSitters"),
            new MeetingPlace(3, "Another")
            );
    }

    private static void SeedAnimalTypes(EntityTypeBuilder<AnimalType> entity)
    {
        entity.HasData(
            new AnimalType(1, "Dog"),
            new AnimalType(2, "Cat")
            );
    }

    private static void SeedBreeds(EntityTypeBuilder<Breed> entity)
    {
        SeedDogBreeds(entity);
        SeedCatBreeds(entity);
    }
    
    private static void SeedDogBreeds(EntityTypeBuilder<Breed> entity)
    {
        entity.HasData(
            Breed.CreateDogBreed("1", "Аффенпинчер"),
            Breed.CreateDogBreed("2","Афганска хрътка"),
            Breed.CreateDogBreed("3","Африканско ловно куче"),
            Breed.CreateDogBreed("4","Еърдейл териер"),
            Breed.CreateDogBreed("5","Акбаш куче"),
            Breed.CreateDogBreed("6","Акита"),
            Breed.CreateDogBreed("7","Алапахски булдог"),
            Breed.CreateDogBreed("8","Аляски хъски"),
            Breed.CreateDogBreed("9","Аляски маламут"),
            Breed.CreateDogBreed("10", "Американски булдог"),
            Breed.CreateDogBreed("11", "Американски були"),
            Breed.CreateDogBreed("12", "Американско ескимоско куче"),
            Breed.CreateDogBreed("13", "Американска лисица"),
            Breed.CreateDogBreed("14", "Американски питбул териер"),
            Breed.CreateDogBreed("15", "Американски стафордширски териер"),
            Breed.CreateDogBreed("16", "Американски воден шпаньол"),
            Breed.CreateDogBreed("17", "Анатолийско пастирско куче"),
            Breed.CreateDogBreed("18", "Апенцелер зененхунд"),
            Breed.CreateDogBreed("19", "Австралийско пастирско куче"),
            Breed.CreateDogBreed("20", "Австралийски келпи"),
            Breed.CreateDogBreed("21", "Австралийска овчарка"),
            Breed.CreateDogBreed("22", "Австралийски териер"),
            Breed.CreateDogBreed("23", "Азавах"),
            Breed.CreateDogBreed("24", "Барбе"),
            Breed.CreateDogBreed("25", "Басенджи"),
            Breed.CreateDogBreed("26", "Гасконски басет"),
            Breed.CreateDogBreed("27", "Басет хрътка"),
            Breed.CreateDogBreed("28", "Бийгъл"),
            Breed.CreateDogBreed("29", "Брадато коли"),
            Breed.CreateDogBreed("30", "Босерон"),
            Breed.CreateDogBreed("31", "Бедлингтон териер"),
            Breed.CreateDogBreed("32", "Белгийски малиноа"),
            Breed.CreateDogBreed("33", "Белгийски тервюрен"),
            Breed.CreateDogBreed("34", "Бернско планинско куче"),
            Breed.CreateDogBreed("35", "Бишон фризе"),
            Breed.CreateDogBreed("36", "Черно-тан кунхаунд"),
            Breed.CreateDogBreed("37", "Блъдхаунд"),
            Breed.CreateDogBreed("38", "Блутик кунхаунд"),
            Breed.CreateDogBreed("39", "Бурбул"),
            Breed.CreateDogBreed("40", "Бордър коли"),
            Breed.CreateDogBreed("41", "Бордър териер"),
            Breed.CreateDogBreed("42", "Бостън териер"),
            Breed.CreateDogBreed("43", "Бувие де Фландр"),
            Breed.CreateDogBreed("44", "Боксер"),
            Breed.CreateDogBreed("45", "Бойкин шпаньол"),
            Breed.CreateDogBreed("46", "Брако Италиано"),
            Breed.CreateDogBreed("47", "Бриар"),
            Breed.CreateDogBreed("48", "Бретонски епаньол"),
            Breed.CreateDogBreed("49", "Бул териер"),
            Breed.CreateDogBreed("50", "Бул мастиф"),
            Breed.CreateDogBreed("51", "Керн териер"),
            Breed.CreateDogBreed("52", "Кане корсо"),
            Breed.CreateDogBreed("53", "Уелско корги кардиган"),
            Breed.CreateDogBreed("54", "Куче леопард от Катахула"),
            Breed.CreateDogBreed("55", "Кавказка овчарка"),
            Breed.CreateDogBreed("56", "Кавалер Кинг Чарлз шпаньол"),
            Breed.CreateDogBreed("57", "Чесапийк бей ретрийвър"),
            Breed.CreateDogBreed("58", "Китайско голо качулато куче"),
            Breed.CreateDogBreed("59", "Китайски шарпей"),
            Breed.CreateDogBreed("60", "Чинук"),
            Breed.CreateDogBreed("61", "Чау Чау"),
            Breed.CreateDogBreed("62", "Кламбър шпаньол"),
            Breed.CreateDogBreed("63", "Кокер шпаньол"),
            Breed.CreateDogBreed("64", "Американски кокер шпаньол"),
            Breed.CreateDogBreed("65", "Котон де тулеар"),
            Breed.CreateDogBreed("66", "Далматинец"),
            Breed.CreateDogBreed("67", "Доберман"),
            Breed.CreateDogBreed("68", "Дого Аржентино"),
            Breed.CreateDogBreed("69", "Холандско пастирско куче"),
            Breed.CreateDogBreed("70", "Английски сетер"),
            Breed.CreateDogBreed("71", "Английско пастирско куче"),
            Breed.CreateDogBreed("72", "Английски спрингер шпаньол"),
            Breed.CreateDogBreed("73", "Английски той шпаньол"),
            Breed.CreateDogBreed("74", "Английски териер"),
            Breed.CreateDogBreed("75", "Евразиец"),
            Breed.CreateDogBreed("76", "Полски шпаньол"),
            Breed.CreateDogBreed("77", "Финландско лапландско куче"),
            Breed.CreateDogBreed("78", "Финландски шпиц"),
            Breed.CreateDogBreed("79", "Френски булдог"),
            Breed.CreateDogBreed("80", "Немски пинчер"),
            Breed.CreateDogBreed("81", "Немска овчарка"),
            Breed.CreateDogBreed("82", "Немски късокосмест пойнтер"),
            Breed.CreateDogBreed("83", "Гигантски шнауцер"),
            Breed.CreateDogBreed("84", "Глен ъф Имаал териер"),
            Breed.CreateDogBreed("85", "Голдън ретрийвър"),
            Breed.CreateDogBreed("86", "Гордън сетер"),
            Breed.CreateDogBreed("87", "Немски мастиф"),
            Breed.CreateDogBreed("88", "Пиренейска планинска овчарка"),
            Breed.CreateDogBreed("89", "Грейхаунд"),
            Breed.CreateDogBreed("90", "Грифон брюкселуа"),
            Breed.CreateDogBreed("91", "Харие"),
            Breed.CreateDogBreed("92", "Хаванез"),
            Breed.CreateDogBreed("93", "Ирландски сетер"),
            Breed.CreateDogBreed("94", "Ирландски териер"),
            Breed.CreateDogBreed("95", "Ирландски вълкодав"),
            Breed.CreateDogBreed("96", "Италиански грейхаунд"),
            Breed.CreateDogBreed("97", "Японски чин"),
            Breed.CreateDogBreed("98", "Японски шпиц"),
            Breed.CreateDogBreed("99", "Кеесхонд"),
            Breed.CreateDogBreed("100", "Комондор"),
            Breed.CreateDogBreed("101", "Койкер хондие"),
            Breed.CreateDogBreed("102", "Кувас"),
            Breed.CreateDogBreed("103", "Лабрадор ретрийвър"),
            Breed.CreateDogBreed("104", "Лагото романьоло"),
            Breed.CreateDogBreed("105", "Ланкашир хийлър"),
            Breed.CreateDogBreed("106", "Леонбергер"),
            Breed.CreateDogBreed("107", "Лхаса апсо"),
            Breed.CreateDogBreed("108", "Малтийско болонезе"),
            Breed.CreateDogBreed("109", "Миниатюрна американска овчарка"),
            Breed.CreateDogBreed("110", "Миниатюрен пинчер"),
            Breed.CreateDogBreed("111", "Миниатюрен шнауцер"),
            Breed.CreateDogBreed("112", "Нюфаундленд"),
            Breed.CreateDogBreed("113", "Норфолк териер"),
            Breed.CreateDogBreed("114", "Норич териер"),
            Breed.CreateDogBreed("115", "Нова шотландска патица ретрийвър"),
            Breed.CreateDogBreed("116", "Староанглийско овчарско куче"),
            Breed.CreateDogBreed("117", "Староанглийски булдог"),
            Breed.CreateDogBreed("118", "Папийон"),
            Breed.CreateDogBreed("119", "Пекинез"),
            Breed.CreateDogBreed("120", "Уелско корги пембрук"),
            Breed.CreateDogBreed("121", "Преса канарио"),
            Breed.CreateDogBreed("122", "Фараонско куче"),
            Breed.CreateDogBreed("123", "Плот хаунд"),
            Breed.CreateDogBreed("124", "Померан"),
            Breed.CreateDogBreed("125", "Пудел миниатюрен"),
            Breed.CreateDogBreed("126", "Пудел той"),
            Breed.CreateDogBreed("127", "Мопс"),
            Breed.CreateDogBreed("128", "Пули"),
            Breed.CreateDogBreed("129", "Пуми"),
            Breed.CreateDogBreed("130", "Рат териер"),
            Breed.CreateDogBreed("131", "Редбоун кунхаунд"),
            Breed.CreateDogBreed("132", "Родезийски риджбек"),
            Breed.CreateDogBreed("133", "Ротвайлер"),
            Breed.CreateDogBreed("134", "Руски той териер"),
            Breed.CreateDogBreed("135", "Санбернар"),
            Breed.CreateDogBreed("136", "Салуки"),
            Breed.CreateDogBreed("137", "Самоед"),
            Breed.CreateDogBreed("138", "Шиперке"),
            Breed.CreateDogBreed("139", "Шотландска еленова хрътка"),
            Breed.CreateDogBreed("140", "Шотландски териер"),
            Breed.CreateDogBreed("141", "Шетландско овчарско куче"),
            Breed.CreateDogBreed("142", "Шиба ину"),
            Breed.CreateDogBreed("143", "Ши Тцу"),
            Breed.CreateDogBreed("144", "Шило пастирско куче"),
            Breed.CreateDogBreed("145", "Сибирско хъски"),
            Breed.CreateDogBreed("146", "Визла"),
            Breed.CreateDogBreed("147", "Ваймаранер")
            );
    }
    
    private static void SeedCatBreeds(EntityTypeBuilder<Breed> entity)
    {
        entity.HasData(
            Breed.CreateCatBreed("148", "Абисинска"),
            Breed.CreateCatBreed("149", "Австралийска мъгла"),
            Breed.CreateCatBreed("150", "Азиатска"),
            Breed.CreateCatBreed("151", "Американска грубокосместа"),
            Breed.CreateCatBreed("152", "Балийска"),
            Breed.CreateCatBreed("153", "Бенгалска"),
            Breed.CreateCatBreed("154", "Бирманска"),
            Breed.CreateCatBreed("155", "Британска късокосместа"),
            Breed.CreateCatBreed("156", "Бурманска"),
            Breed.CreateCatBreed("157", "Бурмила"),
            Breed.CreateCatBreed("158", "Девон Рекс"),
            Breed.CreateCatBreed("159", "Египетска Мау"),
            Breed.CreateCatBreed("160", "Европейска късокосместа"),
            Breed.CreateCatBreed("161", "Канадски сфинкс"),
            Breed.CreateCatBreed("162", "Корат"),
            Breed.CreateCatBreed("163", "Корниш Рекс"),
            Breed.CreateCatBreed("164", "Мейн Куун"),
            Breed.CreateCatBreed("165", "Норвежка горска"),
            Breed.CreateCatBreed("166", "Ориенталска късокосместа"),
            Breed.CreateCatBreed("167", "Персийска"),
            Breed.CreateCatBreed("168", "Петерболд"),
            Breed.CreateCatBreed("169", "Пикси-боб"),
            Breed.CreateCatBreed("170", "Рагдол"),
            Breed.CreateCatBreed("171", "Руска синя"),
            Breed.CreateCatBreed("172", "Селкирк Рекс"),
            Breed.CreateCatBreed("173", "Серенгети"),
            Breed.CreateCatBreed("174", "Сиамска"),
            Breed.CreateCatBreed("175", "Сибирска"),
            Breed.CreateCatBreed("176", "Сингапурска"),
            Breed.CreateCatBreed("177", "Сомалийска"),
            Breed.CreateCatBreed("178", "Тайска"),
            Breed.CreateCatBreed("179", "Тонкинска"),
            Breed.CreateCatBreed("180", "Турска Ангора"),
            Breed.CreateCatBreed("181", "Турски ван"),
            Breed.CreateCatBreed("182", "Украински Левкой"),
            Breed.CreateCatBreed("183", "Уралски Рекс"),
            Breed.CreateCatBreed("184", "Шартрьо"),
            Breed.CreateCatBreed("185", "Шотландска клепоуха"),
            Breed.CreateCatBreed("186", "Японски бобтейл")
            );
    }
    
    private static void SeedAdminAndRoles(ModelBuilder builder)
    {
        string[] roleNames = { "Owner", "Sitter", "Administrator" };
        string roleId = default;
        
        foreach (var role in roleNames)
        {
            roleId = Guid.NewGuid().ToString();
    
            builder
                .Entity<IdentityRole>()
                .HasData(new IdentityRole()
                {
                    Id = roleId,
                    Name = role,
                    NormalizedName = role.ToUpper().Normalize(),
                    ConcurrencyStamp = roleId
                });
        }
        
        var adminId = Guid.NewGuid().ToString();
        var adminEmail = "hristopanev20@gmail.com"; // Has to be changed when official email is created
        var admin = new User
        {
            Id = adminId,
            Email = adminEmail,
            NormalizedEmail = adminEmail.ToUpper().Normalize(),
            EmailConfirmed = true,
            UserName = "admin",
            NormalizedUserName = "ADMIN",
        };
                
        PasswordHasher<User> passwordHasher = new();
        admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin_1234");
    
        builder
            .Entity<User>()
            .HasData(admin);
        
        builder
            .Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>()
            {
                RoleId = roleId,
                UserId = adminId
            });
        
    }
}
