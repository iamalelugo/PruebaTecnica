using GreenLeavesAPI.Data;
using GreenLeavesAPI.DataGLModels;
using Microsoft.EntityFrameworkCore;
using GreenLeavesAPI.Data.DTOS;

namespace GreenLeavesAPI.Services;

public class LoginService{
    private readonly GreenLeavesContext _context;
    public LoginService(GreenLeavesContext context){
        _context = context;
    }

    public async Task<Administrator?> GetAdmin(AdminDto admin){
        return await _context.Administrators.
        SingleOrDefaultAsync( x => x.Email == admin.Email && x.Pwd == admin.Pwd );
    }
}