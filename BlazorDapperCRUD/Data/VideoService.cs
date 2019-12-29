using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDapperCRUD.Data
{
    public class VideoService : IVideoService
    {
        // Database connection
        private readonly SqlConnectionConfiguration _configuration;
        public VideoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Add (create) a Video table row (SQL Insert)
        public async Task<bool> VideoInsert(Video video)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Title", video.Title, DbType.String);
                parameters.Add("DatePublished", video.DatePublished, DbType.Date);
                parameters.Add("IsActive", video.IsActive, DbType.Boolean);
                // Stored procedure method
                await conn.ExecuteAsync("spVideo_Insert", parameters, commandType: CommandType.StoredProcedure);

                // Raw SQL method
                // const string query = @"INSERT INTO Video (Title, DatePublished, IsActive) VALUES (@Title, @DatePublished, @IsActive)";
                // await conn.ExecuteAsync(query, new { video.Title, video.DatePublished, video.IsActive }, commandType: CommandType.Text);
            }
            return true;
        }     

        // Get a list of video rows (SQL Select)
        public async Task<IEnumerable<Video>> VideoList()
        {
            IEnumerable<Video> videos;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                videos = await conn.QueryAsync<Video>("spVideo_GetAll", commandType: CommandType.StoredProcedure);
            }
            return videos;

        }

        // Get one video based on its VideoID (SQL Select)
        public async Task<Video> Video_GetOne(int id)
        {
            Video video = new Video();
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                video = await conn.QueryFirstOrDefaultAsync<Video>("spVideo_GetOne",parameters,commandType: CommandType.StoredProcedure);
            }
            return video;
        }

        // Update one Video row based on its VideoID (SQL Update)
        public async Task<bool> VideoUpdate(Video video)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("VideoID", video.VideoID, DbType.Int32);
                parameters.Add("Title", video.Title, DbType.String);
                parameters.Add("DatePublished", video.DatePublished, DbType.Date);
                parameters.Add("IsActive", video.IsActive, DbType.Boolean);
                await conn.ExecuteAsync("spVideo_Update", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        // Physically delete one Video row based on its VideoID (SQL Delete)
        public async Task<bool> VideoDelete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                await conn.ExecuteAsync("spVideo_Delete",parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }
    }
}
