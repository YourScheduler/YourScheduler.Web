using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Identity;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure
{
    public static class SeedData
    {
        public static ApplicationUser[] userSeed = new ApplicationUser[]
        {
            new ApplicationUser
            {
                Id = 1,
                Name = "admin",
                Surname = "admin",
                Displayname = "admin",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = GetHashPassword("admin"),
                SecurityStamp = GetSecurityStamp(),
                ConcurrencyStamp = "",
                PhoneNumber = "111 222 333",
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                Id = 2,
                Name = "Krzysztof",
                Surname = "Jarzyna",
                Displayname = "kjarzyna",
                UserName = "jarzyna@gmail.com",
                NormalizedUserName = "JARZYNA@GMAIL.COM",
                Email = "jarzyna@gmail.com",
                NormalizedEmail = "JARZYNA@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = GetHashPassword("haslo"),
                SecurityStamp = GetSecurityStamp(),
                ConcurrencyStamp = "",
                PhoneNumber = "666 598 456",
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                Id = 3,
                Name = "Jane",
                Surname = "Johnson",
                Displayname = "Jane",
                UserName = "jane_johnson@gmail.com",
                NormalizedUserName = "JANE_JOHNSON@GMAIL.COM",
                Email = "jane_johnson@gmail.com",
                NormalizedEmail = "JANE_JOHNSON@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = GetHashPassword("Haslohaslo123!"),
                SecurityStamp = GetSecurityStamp(),
                ConcurrencyStamp = "",
                PhoneNumber = "666 598 456",
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                Id = 4,
                Name = "Michael",
                Surname = "Williams",
                Displayname = "willmich",
                UserName = "michaelww@gmail.com",
                NormalizedUserName = "MICHAELWW@GMAIL.COM",
                Email = "michaelww@gmail.com",
                NormalizedEmail = "MICHAELWW@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = GetHashPassword("raz"),
                SecurityStamp = GetSecurityStamp(),
                ConcurrencyStamp = "",
                PhoneNumber = "987 654 321",
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                Id = 5,
                Name = "William",
                Surname = "Jones",
                Displayname = "william",
                UserName = "joneswilliam@gmail.com",
                NormalizedUserName = "JONESWILLIAM@GMAIL.COM",
                Email = "joneswilliam@gmail.com",
                NormalizedEmail = "JONESWILLIAM@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = GetHashPassword("Ebeebe1!"),
                SecurityStamp = GetSecurityStamp(),
                ConcurrencyStamp = "",
                PhoneNumber = "123 456 789",
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                Id = 6,
                Name = "Olivia",
                Surname = "Brown",
                Displayname = "brownie",
                UserName = "oliviab@gmail.com",
                NormalizedUserName = "OLIVIAB@GMAIL.COM",
                Email = "oliviab@gmail.com",
                NormalizedEmail = "OLIVIAB@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = GetHashPassword("sjdhfkjshf33!D"),
                SecurityStamp = GetSecurityStamp(),
                ConcurrencyStamp = "",
                PhoneNumber = "666 598 456",
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            }
        };
        public static Event[] eventSeed = new Event[]
        {
            new Event
            {
                EventId = 1,
                Name = "Koncert Zenka Martyniuka",
                Description = "Koncert z okazji urodzin TVP",
                Date = new DateTime(2023,6,22,19,0,0),
                IsOpen = true,
                AdministratorId = 1,
                PicturePath = "/Pictures/eventId=1.jpg"
            },
            new Event
            {
                EventId = 2,
                Name = "Spotkanie Literackie: Autorzy Bestsellerów",
                Description = "Wyjątkowe spotkanie z autorami bestsellerowych książek",
                Date = new DateTime(2023,12,1,17,0,0),
                IsOpen = true,
                AdministratorId = 1,
                PicturePath = "/Pictures/eventId=2.jpg"
            },
            new Event
            {
                EventId = 3,
                Name = "Występ Teatru Muzycznego: Magiczna Melodia",
                Description = "Spektakl muzyczny pełen magii i emocji",
                Date = new DateTime(2023,10,02,15,0,0),
                IsOpen = true,
                AdministratorId = 2,
                PicturePath = "/Pictures/eventId=3.jpg"
            },
            new Event
            {
                EventId = 4,
                Name = "Konferencja Technologiczna: Przyszłość Innowacji",
                Description = "Najnowsze trendy i innowacje technologiczne na światowym poziomie",
                Date = new DateTime(2023,9,11,12,0,0),
                IsOpen = true,
                AdministratorId = 3,
                PicturePath = "/Pictures/defaultEvent.jpg"
            },
            new Event
            {
                EventId = 5,
                Name = "Sesja Filmowa: Kino bez Granic",
                Description = "Przyjemny wieczór filmowy z wyjątkowymi produkcjami z całego świata",
                Date = new DateTime(2024,1,8,20,0,0),
                IsOpen = false,
                AdministratorId = 4,
                PicturePath = "/Pictures/defaultEvent.jpg"
            },
            new Event
            {
                EventId = 6,
                Name = "Pokaz Kulinarny: Świat Smaków",
                Description = "Wyjątkowy pokaz kulinarny, podczas którego można odkryć smaki z różnych zakątków świata",
                Date = new DateTime(2023,7,15,16,0,0),
                IsOpen = false,
                AdministratorId = 5,
                PicturePath = "/Pictures/eventId=6.jpg"
            },
            new Event
            {
                EventId = 7,
                Name = "Sztuka na Scenie: Wieczór Teatru",
                Description = "Niezwykłe przedstawienie teatralne pełne emocji i wrażeń",
                Date = new DateTime(2023,8,10,18,0,0),
                IsOpen = true,
                AdministratorId = 6,
                PicturePath = "/Pictures/defaultEvent.jpg"
            },
        };
        public static Team[] teamSeed = new Team[]
        {
            new Team
            {
                TeamId = 1,
                Name = "Grupa początkująca basen Chełm",
                Description = "Grupa szkółki pływackiej Argonaut",
                PicturePath = "/Pictures/teamId=1.jpg",
                Creator = "Olivia"
            },
            new Team
            {
                TeamId = 2,
                Name = "Mieszkańcy osiedla Lawendowe Wzgórze",
                Description = "Grupa zrzeszająca mieszkańców osiedla Lawendowe Wzgórze w Gdańsku",
                PicturePath = "/Pictures/teamId=2.jpg",
                Creator = "Wasyl"
            },
            new Team
            {
                TeamId = 3,
                Name = "Kreatywny Warsztat Artystyczny",
                Description = "Zapraszamy do naszego kreatywnego warsztatu artystycznego, gdzie możesz rozwijać swoje umiejętności w różnych dziedzinach sztuki.",
                PicturePath = "/Pictures/defaultTeam.jpg",
                Creator = "Billy"
            },
            new Team
            {
                TeamId = 4,
                Name = "Klub Fitness i Wellness",
                Description = "Dołącz do naszego klubu fitness i wellness, gdzie możesz ćwiczyć, relaksować się i dbać o swoje zdrowie pod okiem profesjonalnych instruktorów.",
                PicturePath="/Pictures/teamId=4.jpg",
                Creator = "Maks"
            },
            new Team
            {
                TeamId = 5,
                Name = "Klub Fotograficzny Obiektyw",
                Description = "Zapraszamy do naszego klubu fotograficznego, gdzie pasjonaci fotografii mogą się spotkać, dzielić się wiedzą i rozwijać swoje umiejętności fotograficzne.",
                PicturePath = "/Pictures/defaultTeam.jpg",
                Creator = "Kokodźambo"
            },
            new Team
            {
                TeamId = 6,
                Name = "Studio Tańca Ritmo",
                Description = "Nasze studio tańca Ritmo oferuje różnorodne style taneczne dla osób w każdym wieku, bez względu na poziom zaawansowania.",
                PicturePath = "/Pictures/defaultTeam.jpg",
                Creator = "PiknaSukna"
            }
        };

        public static TeamRole[] teamRoleSeed = new TeamRole[]
        {
                new TeamRole
                {
                    TeamId = 1,
                    Name = "Chobok",
                    TeamRoleId = 1
                },
                new TeamRole
                {
                    TeamId = 2,
                    Name = "Master Blaster",
                    TeamRoleId = 2
                },
                new TeamRole
                {
                    TeamId = 3,
                    Name = "Perturbator",
                    TeamRoleId = 3
                },
                new TeamRole
                {
                    TeamId = 4,
                    Name = "Ciastek",
                    TeamRoleId = 4
                },
                new TeamRole
                {
                    TeamId = 5,
                    Name = "Kaczucha",
                    TeamRoleId = 5
                },
                new TeamRole
                {
                    TeamId = 6,
                    Name = "Karal",
                    TeamRoleId = 6
                }
        };
        public static TeamRoleFlags[] teamRoleFlagsSeed = new TeamRoleFlags[]
        {
            new TeamRoleFlags()
            {
                TeamRoleId= 1,
                CanAddTeamEvent= true,
                CanRemoveTeamEvent= true,
                CanAddTeamMember= true,
                CanRemoveTeamMember= true,
                CanAddTeamRole= true,
                CanEditDescription= true,
                CanEditRoleFlags= true,
                CanEditTeamEvent= true,
                CanEditTeamMessage= true,
                CanEditTeamName= true,
                CanEditTeamPhoto= true,
                CanEditTeamRole= true,
                CanRemoveTeamRole= true,
                CanSendEmailToTeam= true
            },
            new TeamRoleFlags()
            {
                TeamRoleId= 2,
                CanAddTeamEvent= true,
                CanRemoveTeamEvent= true,
                CanAddTeamMember= true,
                CanRemoveTeamMember= true,
                CanAddTeamRole= true,
                CanEditDescription= true,
                CanEditRoleFlags= true,
                CanEditTeamEvent= true,
                CanEditTeamMessage= true,
                CanEditTeamName= true,
                CanEditTeamPhoto= true,
                CanEditTeamRole= true,
                CanRemoveTeamRole= true,
                CanSendEmailToTeam= true
            },
            new TeamRoleFlags()
            {
                TeamRoleId= 3,
                CanAddTeamEvent= true,
                CanRemoveTeamEvent= true,
                CanAddTeamMember= true,
                CanRemoveTeamMember= true,
                CanAddTeamRole= true,
                CanEditDescription= true,
                CanEditRoleFlags= true,
                CanEditTeamEvent= true,
                CanEditTeamMessage= true,
                CanEditTeamName= true,
                CanEditTeamPhoto= true,
                CanEditTeamRole= true,
                CanRemoveTeamRole= true,
                CanSendEmailToTeam= true
            },
            new TeamRoleFlags()
            {
                TeamRoleId= 4,
                CanAddTeamEvent= true,
                CanRemoveTeamEvent= true,
                CanAddTeamMember= true,
                CanRemoveTeamMember= true,
                CanAddTeamRole= true,
                CanEditDescription= true,
                CanEditRoleFlags= true,
                CanEditTeamEvent= true,
                CanEditTeamMessage= true,
                CanEditTeamName= true,
                CanEditTeamPhoto= true,
                CanEditTeamRole= true,
                CanRemoveTeamRole= true,
                CanSendEmailToTeam= true
            },
            new TeamRoleFlags()
            {
                TeamRoleId= 5,
                CanAddTeamEvent= true,
                CanRemoveTeamEvent= true,
                CanAddTeamMember= true,
                CanRemoveTeamMember= true,
                CanAddTeamRole= true,
                CanEditDescription= true,
                CanEditRoleFlags= true,
                CanEditTeamEvent= true,
                CanEditTeamMessage= true,
                CanEditTeamName= true,
                CanEditTeamPhoto= true,
                CanEditTeamRole= true,
                CanRemoveTeamRole= true,
                CanSendEmailToTeam= true
            },
            new TeamRoleFlags()
            {
                TeamRoleId= 6,
                CanAddTeamEvent= true,
                CanRemoveTeamEvent= true,
                CanAddTeamMember= true,
                CanRemoveTeamMember= true,
                CanAddTeamRole= true,
                CanEditDescription= true,
                CanEditRoleFlags= true,
                CanEditTeamEvent= true,
                CanEditTeamMessage= true,
                CanEditTeamName= true,
                CanEditTeamPhoto= true,
                CanEditTeamRole= true,
                CanRemoveTeamRole= true,
                CanSendEmailToTeam= true
            }


        };
        public static ApplicationUserEvents[] applicationUserEventSeed = new ApplicationUserEvents[]
        {
            new ApplicationUserEvents {ApplicationUserId = 1, EventId = 1},
            new ApplicationUserEvents {ApplicationUserId = 2, EventId = 2},
            new ApplicationUserEvents {ApplicationUserId = 2, EventId = 3},
            new ApplicationUserEvents {ApplicationUserId = 2, EventId = 4},
            new ApplicationUserEvents {ApplicationUserId = 3, EventId = 4},
            new ApplicationUserEvents {ApplicationUserId = 4, EventId = 5},
            new ApplicationUserEvents {ApplicationUserId = 5, EventId = 5},
            new ApplicationUserEvents {ApplicationUserId = 6, EventId = 6}
        };
        public static ApplicationUserTeams[] applicationUserTeamSeed = new ApplicationUserTeams[]
        {
            new ApplicationUserTeams {ApplicationUserId = 1, TeamId = 1, TeamRoleId = 1},
            new ApplicationUserTeams {ApplicationUserId = 2, TeamId = 2, TeamRoleId = 2},
            new ApplicationUserTeams {ApplicationUserId = 2, TeamId = 3, TeamRoleId = 3},
            new ApplicationUserTeams {ApplicationUserId = 2, TeamId = 4, TeamRoleId = 4},
            new ApplicationUserTeams {ApplicationUserId = 3, TeamId = 4, TeamRoleId = 4},
            new ApplicationUserTeams {ApplicationUserId = 4, TeamId = 4, TeamRoleId = 4},
            new ApplicationUserTeams {ApplicationUserId = 5, TeamId = 5, TeamRoleId = 5},
            new ApplicationUserTeams {ApplicationUserId = 5, TeamId = 6, TeamRoleId = 6},
            new ApplicationUserTeams {ApplicationUserId = 6, TeamId = 5, TeamRoleId = 5},
            new ApplicationUserTeams {ApplicationUserId = 6, TeamId = 6, TeamRoleId = 6}
        };
        public static ApplicationUser[] GetUsersSeed()
        {
            return userSeed;
        }
        public static Event[] GetEventsSeed()
        {
            return eventSeed;
        }
        public static Team[] GetTeamsSeed()
        {
            return teamSeed;
        }
        public static TeamRole[] GetTeamRoleSeed()
        {
            return teamRoleSeed;
        }
        public static TeamRoleFlags[] GetTeamRoleFlagsSeed()
        {
            return teamRoleFlagsSeed;
        }
        public static ApplicationUserEvents[] GetApplicationUserEventSeed()
        {
            return applicationUserEventSeed;
        }
        public static ApplicationUserTeams[] GetApplicationUserTeamSeed()
        {
            return applicationUserTeamSeed;
        }
        public const string _base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        public static string GetHashPassword(string password)
        {
            IPasswordHasher _passwordHasher = new PasswordHasher();
            string hashedPassword = _passwordHasher.HashPassword(password);
            return hashedPassword;
        }
        public static string GetSecurityStamp()
        {
            byte[] bytes = new byte[20];
            RandomNumberGenerator.Fill(bytes);
            return ToBase32(bytes);
        }
        public static string ToBase32(byte[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            StringBuilder sb = new StringBuilder();
            for (int offset = 0; offset < input.Length;)
            {
                byte a, b, c, d, e, f, g, h;
                int numCharsToOutput = GetNextGroup(input, ref offset, out a, out b, out c, out d, out e, out f, out g, out h);

                sb.Append((numCharsToOutput >= 1) ? _base32Chars[a] : '=');
                sb.Append((numCharsToOutput >= 2) ? _base32Chars[b] : '=');
                sb.Append((numCharsToOutput >= 3) ? _base32Chars[c] : '=');
                sb.Append((numCharsToOutput >= 4) ? _base32Chars[d] : '=');
                sb.Append((numCharsToOutput >= 5) ? _base32Chars[e] : '=');
                sb.Append((numCharsToOutput >= 6) ? _base32Chars[f] : '=');
                sb.Append((numCharsToOutput >= 7) ? _base32Chars[g] : '=');
                sb.Append((numCharsToOutput >= 8) ? _base32Chars[h] : '=');
            }
            return sb.ToString();
        }
        public static int GetNextGroup(byte[] input, ref int offset, out byte a, out byte b, out byte c, out byte d, out byte e, out byte f, out byte g, out byte h)
        {
            uint b1, b2, b3, b4, b5;

            int retVal;
            switch (input.Length - offset)
            {
                case 1: retVal = 2; break;
                case 2: retVal = 4; break;
                case 3: retVal = 5; break;
                case 4: retVal = 7; break;
                default: retVal = 8; break;
            }

            b1 = (offset < input.Length) ? input[offset++] : 0U;
            b2 = (offset < input.Length) ? input[offset++] : 0U;
            b3 = (offset < input.Length) ? input[offset++] : 0U;
            b4 = (offset < input.Length) ? input[offset++] : 0U;
            b5 = (offset < input.Length) ? input[offset++] : 0U;

            a = (byte)(b1 >> 3);
            b = (byte)(((b1 & 0x07) << 2) | (b2 >> 6));
            c = (byte)((b2 >> 1) & 0x1f);
            d = (byte)(((b2 & 0x01) << 4) | (b3 >> 4));
            e = (byte)(((b3 & 0x0f) << 1) | (b4 >> 7));
            f = (byte)((b4 >> 2) & 0x1f);
            g = (byte)(((b4 & 0x3) << 3) | (b5 >> 5));
            h = (byte)(b5 & 0x1f);

            return retVal;
        }

    }
}
