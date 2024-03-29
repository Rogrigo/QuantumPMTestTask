using Microsoft.EntityFrameworkCore;
using QuantumPMTestTask.Data;

namespace QuantumPMTestTask.Services
{
    public class NoteService
    {
        private readonly ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<NoteModel> GetAllNotes()
        {
            return _context.NotesList.ToList();
        }

        public bool Add(NoteModel note)
        {
            note.CreatedDate = DateTime.UtcNow;
            note.UpdatedDate = DateTime.UtcNow;
            _context.Add(note);
            return Save();
        }
        public bool Delete(NoteModel note)
        {
            _context.Remove(note);
            return Save();
        }
        public bool Update(NoteModel note)
        {
            var existingNote = _context.NotesList.FirstOrDefault(n => n.Id == note.Id);
            if (existingNote != null)
            {
                existingNote.NoteTitle = note.NoteTitle;
                existingNote.NoteText = note.NoteText;
                existingNote.UpdatedDate = DateTime.UtcNow;
                _context.Update(existingNote);
                return Save();
            }
            return false;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<NoteModel> GetByIdAsync(int id)
        {
            return await _context.NotesList.FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}
