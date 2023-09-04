using AutoMapper;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{
    public  class TeamService : ITeamService
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamsRepository teamsRepository, IMapper mapper)
        {
            _teamsRepository = teamsRepository;
            _mapper = mapper;
        }

        public async Task AddTeamAsync(TeamDto teamDto)
        {
            var teamToDatabase=_mapper.Map<Team>(teamDto);
            await _teamsRepository.AddTeamAsync(teamToDatabase);
        }

        public async Task<List<TeamDto>> GetAvailableTeamsAsync(int loggedUserId, string searchString)
        {
            List<TeamDto> teamsDto = new List<TeamDto>();
            var teamsFromDataBase = await _teamsRepository.GetAllExistedTeamsAsync();

            foreach (var teamFromBase in teamsFromDataBase)
            {
                var team = _mapper.Map<TeamDto>(teamFromBase);
                if (loggedUserId == teamFromBase.AdministratorId)
                {
                    team.CanLoggedUserDelete = true;
                    team.CanLoggedUserEdit = true;
                }
                team.IsLoggedUserParticipant = await _teamsRepository.VerifyIsTeamMemberAsync(loggedUserId, team.Id);
                teamsDto.Add(team);
            }
            if (String.IsNullOrEmpty(searchString))
            {
                return teamsDto;
            }
            else
            {
                return teamsDto.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            
        }

        public async Task<TeamDto> GetTeamByIdAsync(int id,int loggedUserId)
        {
            var teamFromDataBase = await _teamsRepository.GetTeamByIdAsync(id);
            var teamDto = _mapper.Map<TeamDto>(teamFromDataBase);
            if (teamDto.AdministratorId==loggedUserId)
            {
                teamDto.CanLoggedUserDelete = true;
                teamDto.CanLoggedUserEdit = true;
            }
            teamDto.IsLoggedUserParticipant = await _teamsRepository.VerifyIsTeamMemberAsync(loggedUserId, teamDto.Id);
            return teamDto;
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _teamsRepository.DeleteTeamByIdAsync(id);
        }

        public async Task DeleteTeamFromCalendarAsync(int id, int userId)
        {
            await _teamsRepository.DeleteTeamFromCalendarByIdAsync(id, userId);
        }

        public async Task UpdateTeamAsync(TeamDto teamDto)
        {
            var teamToBase = _mapper.Map<Team>(teamDto);
            await _teamsRepository.UpdateTeamAsync(teamToBase);
        }

        public async Task AddTeamForUserAsync(int applicationUserId, int teamId)
        {
            await _teamsRepository.AddTeamMemberAsync(applicationUserId, teamId);
        }

        public async Task<List<TeamDto>> GetMyTeamsAsync(int applicationUserId, string searchString)
        {
            List<TeamDto> myTeams = new List<TeamDto>();
            var teamsFromDataBase = await _teamsRepository.GetTeamsForUserAsync(applicationUserId);
            foreach (var team in teamsFromDataBase)
            {
                var teamDto = _mapper.Map<TeamDto>(team);
                if (applicationUserId==team.AdministratorId)
                {
                    teamDto.CanLoggedUserDelete = true;
                    teamDto.CanLoggedUserEdit = true;

                }
                teamDto.IsLoggedUserParticipant = await _teamsRepository.VerifyIsTeamMemberAsync(applicationUserId, teamDto.Id);
                myTeams.Add(teamDto);
            }
            if (String.IsNullOrEmpty(searchString))
            {
                return myTeams;
            }
            else
            {
                return myTeams.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
           
        }
        public async Task<List<ApplicationUserDto>> GetUsersForTeamAsync(int teamtId)
        {
            List<ApplicationUserDto> usersDtos = new List<ApplicationUserDto>();
            var usersForTeam = await _teamsRepository.GetAllTeamMembersForTeamAsync(teamtId);

            foreach (var user in usersForTeam)
            {
                var userDto = _mapper.Map<ApplicationUserDto>(user);
                usersDtos.Add(userDto);
            }
            return usersDtos;
        }
    }
}
