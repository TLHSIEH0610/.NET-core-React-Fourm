using AutoMapper;
using Domain;
using API.DTOs;
using Application.Activities;
using Application.Comments;
namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            string currentUserEmail = null;

            CreateMap<Activity, Activity>();

            //map Activity, ActivityDto
            CreateMap<Activity, ActivityDto>()
                .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Attendees
                    .FirstOrDefault(x => x.IsHost).AppUser.DisplayName))
                                    .ForMember(d => d.HostUserId, o => o.MapFrom(s => s.Attendees
                    .FirstOrDefault(x => x.IsHost).AppUser.Id));
            CreateMap<ActivityAttendee, AttendeeDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(d => d.FollowerCount, o => o.MapFrom(s => s.AppUser.Followers.Count))
                .ForMember(d => d.FollowingCount, o => o.MapFrom(s => s.AppUser.Followings.Count))
                .ForMember(d => d.Following, o => o.MapFrom(s => s.AppUser.Followers.Any(f => f.Observer.Email == currentUserEmail)));

            CreateMap<AppUser, Profiles.Profile>()
            .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(d => d.AppUserId, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.FollowerCount, o => o.MapFrom(s => s.Followers.Count))
            .ForMember(d => d.FollowingCount, o => o.MapFrom(s => s.Followings.Count))
            .ForMember(d => d.Following, o => o.MapFrom(s => s.Followers.Any(f => f.Observer.Email == currentUserEmail)));

            CreateMap<Comment, CommentDto>()
            .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Author.DisplayName))
            .ForMember(d => d.Username, o => o.MapFrom(s => s.Author.UserName))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.Author.Email))
            .ForMember(d => d.Image, o => o.MapFrom(s => s.Author.Email));

            CreateMap<ActivityAttendee, Profiles.UserActivityDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Activity.Id))
            .ForMember(d => d.Date, o => o.MapFrom(s => s.Activity.Date))
            .ForMember(d => d.Title, o => o.MapFrom(s => s.Activity.Title))
            .ForMember(d => d.Category, o => o.MapFrom(s => s.Activity.Category))
            .ForMember(d => d.HostUserId, o => o.MapFrom(s =>
                s.Activity.Attendees.FirstOrDefault(x => x.IsHost).AppUser.Id));

        }
    }
}