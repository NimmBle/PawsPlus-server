using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoolandia.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0030eb75-e251-4c89-afd3-d37f823447a3", "0030eb75-e251-4c89-afd3-d37f823447a3", "Administrator", "ADMINISTRATOR" },
                    { "b4f3e8b0-0ded-4268-b7c5-acd9cf4f2a11", "b4f3e8b0-0ded-4268-b7c5-acd9cf4f2a11", "Sitter", "SITTER" },
                    { "eb56c1eb-485e-4694-9c3e-b8c8e5521651", "eb56c1eb-485e-4694-9c3e-b8c8e5521651", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "48f7a329-7f4b-4203-a388-e6b43df53cb2", 0, "199cefe5-944a-4cb6-b1d3-3af15b2ce6fd", "hristopanev20@gmail.com", true, false, null, "HRISTOPANEV20@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEE9rxy1X1TDj4l1+jh1zt2K7/UW1Q9N+B0oPy58n65VOeDxEHw3Bmqvyl6e2ns+dwA==", null, false, null, "1d86d206-40b0-4e78-b096-c8366ea1b44e", false, "admin" });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "008a68a6-c879-4710-b99c-c9287ee6e66e", "Нова шотландска патица ретривър" },
                    { "05657640-c961-4367-9a44-613cfad6dd7f", "Английски той спаниел" },
                    { "088931dd-abc3-43d4-9abb-d265af2f73a1", "Гладък фокс териер" },
                    { "09ce802e-a6f9-4575-8bd3-41faf28394a2", "Американски були" },
                    { "0b86eea9-fc47-417e-996d-993a2c2cec2e", "Басенджи" },
                    { "0c1c2787-00ec-4ef4-9d3a-74643b93a8b3", "Пуми" },
                    { "0fb9c8a7-9dd2-49b2-b3fd-95556c18bad5", "Шетландско овчарско куче" },
                    { "0fd22c97-1652-48fd-a591-9b8ddb407578", "Холандска овчарка" },
                    { "1131eb14-4185-46a7-b40c-91243602c3c7", "Басет Гаскон" },
                    { "1187bcc4-2613-4a12-9533-664d61a74fcb", "Белгийски тервюрен" },
                    { "119529bf-b243-47a0-8703-51fead148b0d", "Чинук" },
                    { "120aac19-7d56-46c1-b2d5-de6c19ba363a", "Тибетски спаниел" },
                    { "155e0de4-7848-437c-8417-540d598fd43c", "Ротвайлер" },
                    { "18bd3272-8bf6-4fdc-bc4d-06ee6c5e102d", "Бретон" },
                    { "1afbd14d-cfef-4602-8a27-e7eeb9c80975", "Японски шпиц" },
                    { "1b8569b9-4fc4-4666-88a3-3b9b3e24b68b", "Грейхаунд" },
                    { "1cb8f21e-0c8e-4706-888c-74d84e9093a0", "Комондор" },
                    { "1d914e82-4d03-4e6c-99a6-92a48a830d43", "Акита" },
                    { "1e6b7c65-bf5d-44ed-9395-b7d10550ec89", "Бишон фризе" },
                    { "2122ac4d-a187-4a62-86c7-203c0c8a6600", "Свети Бернар" },
                    { "2127e22e-fd96-4a45-b072-31b4296653e6", "Малтийска болонка" },
                    { "2145cad1-6e04-41bc-be45-bab93023b4a2", "Бойкин спаниел" },
                    { "2181effe-3204-4f23-99f3-f67806a75e18", "Анатолийско пастирско куче" },
                    { "237fe6f8-b675-491e-adcf-0ecd3fee3a2a", "Голдън ретривър" },
                    { "26067593-b432-4921-8c80-75caf4a0bdf2", "Кавказка овчарка" },
                    { "2638067f-b5fc-428a-8804-e2a6e758f3c6", "Френски булдог" },
                    { "26c267a2-445c-41ae-9e19-2f7acf6df182", "Миниатюрен шнауцер" },
                    { "273d38b6-96a6-441e-b3c9-98fdba49eb35", "Барбе" },
                    { "2d7546a2-3121-453b-b264-504b188e114c", "Далматинец" },
                    { "2ffe991a-ed1b-4c8f-be6e-54e64a7aae25", "Алапахски булдог" },
                    { "30283d66-cebd-4f5b-aaa7-280b4a7d84c9", "Глен имаал териер" },
                    { "324fbd2b-2382-40dc-b123-cbf0ca0c4c51", "Старо английско овчарско куче" },
                    { "3570c569-c20e-4129-bd5c-0cb540132d61", "Испанско водно куче" },
                    { "394debaf-70c5-40a8-8813-0c3f2d2c8653", "Блъдхаунд" },
                    { "3d285c30-dafd-48aa-9db1-61d2ae09a674", "Пекинез" },
                    { "429d5c44-c6ea-4e4d-8d81-c6214b5ef228", "Лхаса апсо" },
                    { "4331e2e7-4341-40c7-8ca6-074411e28b91", "Американска лисица" },
                    { "446ebe17-dfdd-431c-8ad2-c967b6fb2265", "Гордън сетер" },
                    { "4470850a-4aae-4836-b880-3eb7b654bf1e", "Леонбергер" },
                    { "45369fd4-ac48-47da-ba26-2168977181fb", "Пули" },
                    { "45c1c55b-7e05-4d5e-a5b6-86cd43cb2af1", "Шило овчар" },
                    { "4627b48d-c68b-4c97-8cd6-c04364cde8ae", "Черно-тан кунхаунд" },
                    { "46289fba-e0f7-40fb-bca8-255faa635353", "Апензелер сененхунд" },
                    { "46e47479-81ab-4ee2-8832-96949c33ed1b", "Уелско корги пембрук" },
                    { "471d5bb9-754e-4fd1-994c-68b5fb2c049f", "Бийгъл" },
                    { "49decdd4-a07b-41fc-ad7b-e3531c9adfc2", "Пудел той" },
                    { "4e2bf30a-2655-4722-b9fb-978a461174e6", "Тибетски териер" },
                    { "4f41ba5a-3127-4ad2-abcd-214057a2efa8", "Лабрадор ретривър" },
                    { "525e6cde-5bb5-40a0-b88c-2559ee698839", "Австралийска овчарка" },
                    { "53fa79a2-ff46-498a-844e-4187b4bb7a75", "Норич териер" },
                    { "56896123-95b6-4080-bef0-4fff0075f3a5", "Доберман" },
                    { "569e5432-e2aa-4615-8c94-e8a52550797b", "Бедлингтон териер" },
                    { "58e8d596-2b63-4fb8-844c-23201e04288d", "Руска той териер" },
                    { "59e76a57-b55f-4d71-ac9e-44452fde66fd", "Бувие де Фландр" },
                    { "5d4a8036-4271-4bbe-8c55-6520c215133f", "Шотландски териер" },
                    { "5dfe3489-0073-44dd-94f5-45096291efca", "Пиренейска планинска овчарка" },
                    { "5edf7e4f-8bea-4545-b2b1-673038af4118", "Китайско хохлато куче" },
                    { "63c4244b-6175-4899-bb3b-455a75e05a73", "Мини американска овчарка" },
                    { "644cae7e-7c19-438b-854d-f106d31ac9fb", "Салуки" },
                    { "651207a0-6fbb-4245-8265-d80dc566d1f0", "Немски късокосмест пойнтер" },
                    { "65d29b58-3dd5-4e6d-bd75-5ef705bff8b1", "Шотландски еленов хрътка" },
                    { "666db580-91a5-439d-acf7-7ecd9a3903d7", "Кокер спаниел" },
                    { "67b4f3ca-9f50-41f5-b38b-97ee944138fa", "Италианска хрътка" },
                    { "6c2bb3c0-f02b-4a75-b5f5-ae9fd9b29e17", "Спиноне Италиано" },
                    { "6dbde251-779d-4e6f-8c57-5712f7f0b8ba", "Бриар" },
                    { "6f07b960-1df3-4d61-93b0-e493578933a8", "Английска овчарка" },
                    { "6f2b8519-2e64-496e-bd33-d245253e4c91", "Померан" },
                    { "6fd145d2-1166-4d47-b1f0-e8f858eee41f", "Стафордширски бул териер" },
                    { "70dcd163-badd-4d76-9b70-6e18ffce5b1b", "Мопс" },
                    { "71b67024-ea6b-498c-b45d-edf137e35ef1", "Бурбул" },
                    { "72d7d858-07c7-47f0-9d59-4cea618ebe70", "Африканско ловно куче" },
                    { "76398435-deb4-4f5a-ad2d-18d7cda31fb2", "Австралийски териер" },
                    { "766dab57-e828-4c54-8841-110de83f4ff9", "Играчка фокс териер" },
                    { "7bf9398c-8596-43a1-a085-d2e1d8068a81", "Дого Аржентино" },
                    { "7c24dbd5-e904-472e-9b0a-7e2fee11c2c6", "Катахула леопард куче" },
                    { "7ceefaac-9ff2-4d53-9176-5c27c0b0a335", "Бордър коли" },
                    { "7d4e3e50-1a48-4471-9ab2-3f36fdc2c34f", "Тибетски мастиф" },
                    { "85a26ec1-82fb-409b-a4dc-42221b998dc7", "Американско ескимоско куче" },
                    { "8734a595-87d3-43b3-930e-f089866c5fd1", "Финландско лапландско куче" },
                    { "878c3159-6ed2-4049-80cb-e627a7482c21", "Американски питбул териер" },
                    { "87cf3b49-beb0-4339-b621-f0affe704a42", "Шиба ину" },
                    { "899a9791-49b8-4465-b88e-c5f195069346", "Ланкашър хийлър" },
                    { "89bf4a88-4613-4a77-888f-8b16b891bed8", "Ирландски сетер" },
                    { "8c73c36d-ee30-4fed-8b0a-b0e623d24b3d", "Басет хрътка" },
                    { "8d7c1e5e-83ba-44d9-a10e-46454dfaa09f", "Шиперке" },
                    { "8fdaa201-6e09-402e-8a25-243e53303646", "Австралийски келпи" },
                    { "90ad73f4-7046-474e-9d41-041ded1233c6", "Чесапийк бей ретривър" },
                    { "90fabfdd-f82b-4c32-8a53-c72aa9dbbddc", "Американски стафордширски териер" },
                    { "91e0d574-0484-4189-8186-1c5b90948bc7", "Ирландски вълкодав" },
                    { "94034642-b551-4f9a-9f17-cc66efe86d7a", "Брадато коли" },
                    { "95055a73-9503-4924-9df2-ea3994ccc789", "Аляски хъски" },
                    { "96556aa4-3a11-4b23-904c-15be0247e556", "Белгийски малиноа" },
                    { "9878caa5-3e16-4f3d-9ac9-1df8fc8a86f6", "Копринено териер" },
                    { "9a9a0b39-0b91-490e-9b32-a16f8a365988", "Американски воден спаниел" },
                    { "9af7e45f-78b9-4a3f-9970-94896d16c925", "Норфолк териер" },
                    { "9b8a367d-abb8-476e-b2a1-cca3e14917d8", "Блутик кунхаунд" },
                    { "9da898ea-dcb9-4047-abd0-05821d88c0d8", "Бордър териер" },
                    { "9e1310b9-d207-40ab-8576-d2729f176de2", "Чау Чау" },
                    { "a304abda-2627-493a-a32e-a394b40443d9", "Кеесхонд" },
                    { "a8a24aad-b3be-4590-ae85-b9d1bf3532dc", "Бул мастиф" },
                    { "a8f222d5-40eb-4ab3-8014-567c5b2fd340", "Аляски маламут" },
                    { "a9474ee6-a735-4344-9eb7-56d39dcd9082", "Лагото романьоло" },
                    { "a979f0c7-88bc-4f51-9086-1e6f937ac367", "Китайски шарпей" },
                    { "ad7db344-2af4-45eb-89b5-0847c1ee3bda", "Плот" },
                    { "af516786-cf92-46d7-b45f-d87238ea7bb4", "Айредейл териер" },
                    { "af9258d4-8384-4a5d-bf12-60164fc4eec7", "Немски пинчер" },
                    { "b000a904-221d-4abb-9115-4e1b77757b6e", "Папийон" },
                    { "b06d371d-3a5a-4c65-8947-b80679c7e84c", "Койкер хондже" },
                    { "b2d0518a-344f-487c-a71f-80b9b65e1fc8", "Азавах" },
                    { "b2e77a64-41eb-4435-b3cc-d8c54faac668", "Акбаш куче" },
                    { "b372e082-d272-4e02-a4c0-4bef8c3b6ddf", "Мека пшенична териер" },
                    { "b435aac5-c9bd-4485-92e7-b26c047df248", "Кокер американски" },
                    { "b7f3750a-529d-48a7-8781-a71e759634c1", "Аффенпинчер" },
                    { "bd2c30f1-2c66-45e4-aecc-2a7881b110b4", "Бернско планинско куче" },
                    { "be3bb04b-0c46-4a3b-a30a-c8c9c3aa0839", "Боксер" },
                    { "c12dff1d-67e2-46b3-827a-dcbbc8c1225d", "Редбоун кунхаунд" },
                    { "c2635807-10d8-494d-9878-a467d1c06873", "Американски булдог" },
                    { "c3d16897-3490-4db0-bd6b-8044c78a8b1c", "Шведски валхунд" },
                    { "c83fef2a-8201-4c50-8899-0db225329ea8", "Грифон брюкселуа" },
                    { "c8941f55-d4cb-483b-8c49-27ca74237598", "Бостън териер" },
                    { "c9e582f2-9cd9-4f62-857c-e0e551cd4bcc", "Кавалер Кинг Чарлз спаниел" },
                    { "ca6085c5-fe49-4100-bb49-dc0d19788ff1", "Дървесен уокър кунхаунд" },
                    { "ca6f547a-cee0-4d20-b717-d4a986a58114", "Немски дог" },
                    { "cbc63ccd-cfa2-4953-8194-19ee47e54c5c", "Евразиец" },
                    { "cd8de5df-cafc-42d0-8f96-ca7ae0e6b3dc", "Клъмбър спаниел" },
                    { "cda3d20c-6234-4be8-a182-bc5169f6123c", "Английски териер" },
                    { "d13431d4-f3f6-4b68-bea2-fcf5d6288f2b", "Котон де Тулеар" },
                    { "d40d0a3b-bc12-4884-8d3b-f2baeb772d58", "Ваймаранер" },
                    { "d4532717-1bbe-452d-8a13-bd2bd15d9f59", "Сибирско хъски" },
                    { "d4a39613-9343-4c2d-a151-62b6949331cc", "Финландски шпиц" },
                    { "d6ee7c7c-095f-4ec4-8f1d-d18924bc1e7f", "Английски спрингер спаниел" },
                    { "d747061b-3839-4031-ae9b-d218e0508835", "Австралийско пастирско куче" },
                    { "d7f19651-38d2-4d8c-9030-6ffee4a45d61", "Босерон" },
                    { "d8c6d422-e640-4586-b4ca-2d678538f694", "Нюфаундленд" },
                    { "da54f688-e5f7-4586-a5a3-e3fda7c230d9", "Бул териер" },
                    { "dee993f3-4592-4d2f-9033-91aa58ee162e", "Гигантски шнауцер" },
                    { "dfd72ca2-2edb-46d7-b8c0-2c41c390f220", "Немска овчарка" },
                    { "e049c369-4e63-4d22-bb79-5790cf9481ad", "Японски чин" },
                    { "e071f902-df40-4a36-9697-b88271ef6269", "Фараонско куче" },
                    { "e318bcdc-371a-4894-bcea-c00f28a1e972", "Стандартен шнауцер" },
                    { "e4669323-0b89-4b56-9164-a002939daf80", "Кардиган уелско корги" },
                    { "e49f123b-3850-4e70-a161-59b301eba289", "Самоед" },
                    { "e5ccb9fd-4e19-41cb-ad9d-58893207f737", "Плъхов териер" },
                    { "e7202a83-3e66-4519-a56f-2fa8543da263", "Пудел миниатюрен" },
                    { "e75993d4-8b57-4730-89f9-e6ec1da671fc", "Перро депреса канарио" },
                    { "e79de270-bbe8-48e2-8dba-7f1362523edd", "Английски сетер" },
                    { "e85e176a-4a29-40b3-ac09-de9745f172a4", "Родезийски риджбек" },
                    { "ea6474c6-5290-49ed-8b69-a139704ee34f", "Оригинален английски булдог" },
                    { "ecad49c5-1368-420e-99b3-e71f47ab44ea", "Ши Тцу" },
                    { "ef2580e0-17ce-477d-bd27-f488240855d7", "Ирландски териер" },
                    { "f00a505e-1f8d-444c-8d1b-78952b3dc66e", "Кувас" },
                    { "f09d4845-c139-413d-baa8-49e479e7aa2f", "Афганска хрътка" },
                    { "f0f11b0b-a3aa-4b11-b917-0f24118f6830", "Визла" },
                    { "f14e847c-fb4e-4caf-bbff-1156f4e52049", "Брако Италиано" },
                    { "f16a76b7-0661-4077-a0b1-a94aab1e6ee4", "Кеърн териер" },
                    { "f22b2fa4-300e-4cf5-82e2-99ebd1ed8acd", "Хаванез" },
                    { "f47e8ea1-ca18-42a7-8dcd-09f6e4bd524a", "Полски спаниел" },
                    { "fcdaa1f3-a583-4cb6-80d6-34497b499a88", "Тайландско гребено куче" },
                    { "fd96ec10-cd13-4afc-8205-4b347a94c029", "Харие" },
                    { "fe7b0154-6186-45b9-a4b9-3b928ca87f6f", "Кане корсо" },
                    { "ffa5460b-d0ac-4be1-8510-04666bacb6da", "Миниатюрен пинчер" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0030eb75-e251-4c89-afd3-d37f823447a3", "48f7a329-7f4b-4203-a388-e6b43df53cb2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4f3e8b0-0ded-4268-b7c5-acd9cf4f2a11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb56c1eb-485e-4694-9c3e-b8c8e5521651");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0030eb75-e251-4c89-afd3-d37f823447a3", "48f7a329-7f4b-4203-a388-e6b43df53cb2" });

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "008a68a6-c879-4710-b99c-c9287ee6e66e");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "05657640-c961-4367-9a44-613cfad6dd7f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "088931dd-abc3-43d4-9abb-d265af2f73a1");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "09ce802e-a6f9-4575-8bd3-41faf28394a2");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "0b86eea9-fc47-417e-996d-993a2c2cec2e");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "0c1c2787-00ec-4ef4-9d3a-74643b93a8b3");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "0fb9c8a7-9dd2-49b2-b3fd-95556c18bad5");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "0fd22c97-1652-48fd-a591-9b8ddb407578");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "1131eb14-4185-46a7-b40c-91243602c3c7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "1187bcc4-2613-4a12-9533-664d61a74fcb");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "119529bf-b243-47a0-8703-51fead148b0d");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "120aac19-7d56-46c1-b2d5-de6c19ba363a");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "155e0de4-7848-437c-8417-540d598fd43c");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "18bd3272-8bf6-4fdc-bc4d-06ee6c5e102d");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "1afbd14d-cfef-4602-8a27-e7eeb9c80975");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "1b8569b9-4fc4-4666-88a3-3b9b3e24b68b");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "1cb8f21e-0c8e-4706-888c-74d84e9093a0");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "1d914e82-4d03-4e6c-99a6-92a48a830d43");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "1e6b7c65-bf5d-44ed-9395-b7d10550ec89");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2122ac4d-a187-4a62-86c7-203c0c8a6600");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2127e22e-fd96-4a45-b072-31b4296653e6");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2145cad1-6e04-41bc-be45-bab93023b4a2");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2181effe-3204-4f23-99f3-f67806a75e18");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "237fe6f8-b675-491e-adcf-0ecd3fee3a2a");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "26067593-b432-4921-8c80-75caf4a0bdf2");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2638067f-b5fc-428a-8804-e2a6e758f3c6");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "26c267a2-445c-41ae-9e19-2f7acf6df182");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "273d38b6-96a6-441e-b3c9-98fdba49eb35");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2d7546a2-3121-453b-b264-504b188e114c");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2ffe991a-ed1b-4c8f-be6e-54e64a7aae25");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "30283d66-cebd-4f5b-aaa7-280b4a7d84c9");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "324fbd2b-2382-40dc-b123-cbf0ca0c4c51");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "3570c569-c20e-4129-bd5c-0cb540132d61");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "394debaf-70c5-40a8-8813-0c3f2d2c8653");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "3d285c30-dafd-48aa-9db1-61d2ae09a674");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "429d5c44-c6ea-4e4d-8d81-c6214b5ef228");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "4331e2e7-4341-40c7-8ca6-074411e28b91");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "446ebe17-dfdd-431c-8ad2-c967b6fb2265");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "4470850a-4aae-4836-b880-3eb7b654bf1e");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "45369fd4-ac48-47da-ba26-2168977181fb");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "45c1c55b-7e05-4d5e-a5b6-86cd43cb2af1");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "4627b48d-c68b-4c97-8cd6-c04364cde8ae");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "46289fba-e0f7-40fb-bca8-255faa635353");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "46e47479-81ab-4ee2-8832-96949c33ed1b");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "471d5bb9-754e-4fd1-994c-68b5fb2c049f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "49decdd4-a07b-41fc-ad7b-e3531c9adfc2");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "4e2bf30a-2655-4722-b9fb-978a461174e6");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "4f41ba5a-3127-4ad2-abcd-214057a2efa8");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "525e6cde-5bb5-40a0-b88c-2559ee698839");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "53fa79a2-ff46-498a-844e-4187b4bb7a75");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "56896123-95b6-4080-bef0-4fff0075f3a5");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "569e5432-e2aa-4615-8c94-e8a52550797b");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "58e8d596-2b63-4fb8-844c-23201e04288d");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "59e76a57-b55f-4d71-ac9e-44452fde66fd");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "5d4a8036-4271-4bbe-8c55-6520c215133f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "5dfe3489-0073-44dd-94f5-45096291efca");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "5edf7e4f-8bea-4545-b2b1-673038af4118");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "63c4244b-6175-4899-bb3b-455a75e05a73");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "644cae7e-7c19-438b-854d-f106d31ac9fb");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "651207a0-6fbb-4245-8265-d80dc566d1f0");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "65d29b58-3dd5-4e6d-bd75-5ef705bff8b1");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "666db580-91a5-439d-acf7-7ecd9a3903d7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "67b4f3ca-9f50-41f5-b38b-97ee944138fa");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "6c2bb3c0-f02b-4a75-b5f5-ae9fd9b29e17");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "6dbde251-779d-4e6f-8c57-5712f7f0b8ba");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "6f07b960-1df3-4d61-93b0-e493578933a8");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "6f2b8519-2e64-496e-bd33-d245253e4c91");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "6fd145d2-1166-4d47-b1f0-e8f858eee41f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "70dcd163-badd-4d76-9b70-6e18ffce5b1b");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "71b67024-ea6b-498c-b45d-edf137e35ef1");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "72d7d858-07c7-47f0-9d59-4cea618ebe70");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "76398435-deb4-4f5a-ad2d-18d7cda31fb2");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "766dab57-e828-4c54-8841-110de83f4ff9");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "7bf9398c-8596-43a1-a085-d2e1d8068a81");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "7c24dbd5-e904-472e-9b0a-7e2fee11c2c6");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "7ceefaac-9ff2-4d53-9176-5c27c0b0a335");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "7d4e3e50-1a48-4471-9ab2-3f36fdc2c34f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "85a26ec1-82fb-409b-a4dc-42221b998dc7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "8734a595-87d3-43b3-930e-f089866c5fd1");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "878c3159-6ed2-4049-80cb-e627a7482c21");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "87cf3b49-beb0-4339-b621-f0affe704a42");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "899a9791-49b8-4465-b88e-c5f195069346");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "89bf4a88-4613-4a77-888f-8b16b891bed8");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "8c73c36d-ee30-4fed-8b0a-b0e623d24b3d");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "8d7c1e5e-83ba-44d9-a10e-46454dfaa09f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "8fdaa201-6e09-402e-8a25-243e53303646");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "90ad73f4-7046-474e-9d41-041ded1233c6");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "90fabfdd-f82b-4c32-8a53-c72aa9dbbddc");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "91e0d574-0484-4189-8186-1c5b90948bc7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "94034642-b551-4f9a-9f17-cc66efe86d7a");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "95055a73-9503-4924-9df2-ea3994ccc789");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "96556aa4-3a11-4b23-904c-15be0247e556");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "9878caa5-3e16-4f3d-9ac9-1df8fc8a86f6");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "9a9a0b39-0b91-490e-9b32-a16f8a365988");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "9af7e45f-78b9-4a3f-9970-94896d16c925");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "9b8a367d-abb8-476e-b2a1-cca3e14917d8");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "9da898ea-dcb9-4047-abd0-05821d88c0d8");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "9e1310b9-d207-40ab-8576-d2729f176de2");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "a304abda-2627-493a-a32e-a394b40443d9");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "a8a24aad-b3be-4590-ae85-b9d1bf3532dc");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "a8f222d5-40eb-4ab3-8014-567c5b2fd340");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "a9474ee6-a735-4344-9eb7-56d39dcd9082");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "a979f0c7-88bc-4f51-9086-1e6f937ac367");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "ad7db344-2af4-45eb-89b5-0847c1ee3bda");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "af516786-cf92-46d7-b45f-d87238ea7bb4");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "af9258d4-8384-4a5d-bf12-60164fc4eec7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "b000a904-221d-4abb-9115-4e1b77757b6e");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "b06d371d-3a5a-4c65-8947-b80679c7e84c");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "b2d0518a-344f-487c-a71f-80b9b65e1fc8");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "b2e77a64-41eb-4435-b3cc-d8c54faac668");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "b372e082-d272-4e02-a4c0-4bef8c3b6ddf");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "b435aac5-c9bd-4485-92e7-b26c047df248");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "b7f3750a-529d-48a7-8781-a71e759634c1");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "bd2c30f1-2c66-45e4-aecc-2a7881b110b4");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "be3bb04b-0c46-4a3b-a30a-c8c9c3aa0839");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "c12dff1d-67e2-46b3-827a-dcbbc8c1225d");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "c2635807-10d8-494d-9878-a467d1c06873");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "c3d16897-3490-4db0-bd6b-8044c78a8b1c");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "c83fef2a-8201-4c50-8899-0db225329ea8");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "c8941f55-d4cb-483b-8c49-27ca74237598");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "c9e582f2-9cd9-4f62-857c-e0e551cd4bcc");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "ca6085c5-fe49-4100-bb49-dc0d19788ff1");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "ca6f547a-cee0-4d20-b717-d4a986a58114");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "cbc63ccd-cfa2-4953-8194-19ee47e54c5c");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "cd8de5df-cafc-42d0-8f96-ca7ae0e6b3dc");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "cda3d20c-6234-4be8-a182-bc5169f6123c");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "d13431d4-f3f6-4b68-bea2-fcf5d6288f2b");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "d40d0a3b-bc12-4884-8d3b-f2baeb772d58");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "d4532717-1bbe-452d-8a13-bd2bd15d9f59");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "d4a39613-9343-4c2d-a151-62b6949331cc");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "d6ee7c7c-095f-4ec4-8f1d-d18924bc1e7f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "d747061b-3839-4031-ae9b-d218e0508835");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "d7f19651-38d2-4d8c-9030-6ffee4a45d61");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "d8c6d422-e640-4586-b4ca-2d678538f694");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "da54f688-e5f7-4586-a5a3-e3fda7c230d9");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "dee993f3-4592-4d2f-9033-91aa58ee162e");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "dfd72ca2-2edb-46d7-b8c0-2c41c390f220");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e049c369-4e63-4d22-bb79-5790cf9481ad");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e071f902-df40-4a36-9697-b88271ef6269");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e318bcdc-371a-4894-bcea-c00f28a1e972");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e4669323-0b89-4b56-9164-a002939daf80");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e49f123b-3850-4e70-a161-59b301eba289");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e5ccb9fd-4e19-41cb-ad9d-58893207f737");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e7202a83-3e66-4519-a56f-2fa8543da263");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e75993d4-8b57-4730-89f9-e6ec1da671fc");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e79de270-bbe8-48e2-8dba-7f1362523edd");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "e85e176a-4a29-40b3-ac09-de9745f172a4");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "ea6474c6-5290-49ed-8b69-a139704ee34f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "ecad49c5-1368-420e-99b3-e71f47ab44ea");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "ef2580e0-17ce-477d-bd27-f488240855d7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "f00a505e-1f8d-444c-8d1b-78952b3dc66e");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "f09d4845-c139-413d-baa8-49e479e7aa2f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "f0f11b0b-a3aa-4b11-b917-0f24118f6830");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "f14e847c-fb4e-4caf-bbff-1156f4e52049");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "f16a76b7-0661-4077-a0b1-a94aab1e6ee4");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "f22b2fa4-300e-4cf5-82e2-99ebd1ed8acd");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "f47e8ea1-ca18-42a7-8dcd-09f6e4bd524a");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "fcdaa1f3-a583-4cb6-80d6-34497b499a88");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "fd96ec10-cd13-4afc-8205-4b347a94c029");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "fe7b0154-6186-45b9-a4b9-3b928ca87f6f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "ffa5460b-d0ac-4be1-8510-04666bacb6da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0030eb75-e251-4c89-afd3-d37f823447a3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48f7a329-7f4b-4203-a388-e6b43df53cb2");
        }
    }
}
