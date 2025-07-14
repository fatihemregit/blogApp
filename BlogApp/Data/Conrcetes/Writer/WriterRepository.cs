using AutoMapper;
using BlogApp.Data.Abstracts.Writer;
using BlogApp.Data.Context;
using BlogApp.Models.IWriterRepository;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Conrcetes.Writer
{
    public class WriterRepository : IWriterRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public WriterRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IWriterRepositoryCrateOneWriterAsyncResponse?> CrateOneWriterAsync(IWriterRepositoryCrateOneWriterAsyncRequest writer)
        {
            Models.Writer writerDto = _mapper.Map<Models.Writer>(writer);
            await _context.Writers.AddAsync(writerDto);
            int result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return null;
            }
            return _mapper.Map<IWriterRepositoryCrateOneWriterAsyncResponse>(writerDto);
        }
        public async Task<IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse?> GetOneWriterWithWriterIdAsync(IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest writer)
        {
            Models.Writer? writerInDb = await _context.Writers.FirstOrDefaultAsync(w => w.Id == writer.Id);
            if (writerInDb is null)
            {
                return null;
            }
            return _mapper.Map<IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse>(writerInDb);
        }

        public async Task<List<IWriterRepositoryGetAllWriterAsyncResponse>?> GetAllWriterAsync()
        {
            List<Models.Writer> writersInDb = await _context.Writers.ToListAsync();
            if (writersInDb.Count <= 0)
            {
                return null;
            }
            return _mapper.Map<List<IWriterRepositoryGetAllWriterAsyncResponse>>(writersInDb);

        }

        public async Task<IWriterRepositoryUpdateOneWriterResponse?> UpdateOneWriter(IWriterRepositoryUpdateOneWriterRequest writer)
        {
            Models.Writer? writerInDb = await _context.Writers.FirstOrDefaultAsync(w =>w.Id == writer.Id);
            if (writerInDb is null)
            {
                return null;
            }
            writerInDb.Name = writer.Name;
            writerInDb.Description = writer.Description;
            writerInDb.profileUrl = writer.profileUrl;
            writerInDb.AppUserId = writer.AppUserId;
            _context.Writers.Update(writerInDb);
            int result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return null;
            }
            return _mapper.Map<IWriterRepositoryUpdateOneWriterResponse>(writerInDb);
        }

        public async Task<bool> DeleteOneWriter(IWriterRepositoryDeleteOneWriterRequest writer)
        {
            //Daha sonralarında safe delete kullanalım
            Models.Writer? writerInDb = await _context.Writers.FirstOrDefaultAsync(w => w.Id == writer.Id);
            if (writerInDb is null)
            {
                return false;
            }
            _context.Writers.Remove(writerInDb);
            int result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return false;
            }
            return true;
        }


    }
}
