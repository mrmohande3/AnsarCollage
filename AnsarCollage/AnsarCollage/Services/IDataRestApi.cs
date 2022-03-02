using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnsarCollage.Models;
using Refit;

namespace AnsarCollage.Services
{
    public interface IDataRestApi
    {
        [Get("/get-field/")]
        Task<ApiResult<FieldResponse>> GetFields([Header("Authorization")]string authorize);

        [Get("/get-grades/")]
        Task<ApiResult<GradeResponse>> GetGrades([Query]int field_id, [Header("Authorization")] string authorize);

        [Get("/get-courses/")]
        Task<ApiResult<CoursResponse>> GetCurses([Query]int grade_id, [Header("Authorization")] string authorize);

        [Get("/get-chapters/")]
        Task<ApiResult<ChapterReponse>> GetChapter(int course_id, [Header("Authorization")] string authorize);

        [Get("/get-files/")]
        Task<ApiResult<FileResponse>> GetFiles(int chapter_id, [Header("Authorization")] string authorize);
    }
}
