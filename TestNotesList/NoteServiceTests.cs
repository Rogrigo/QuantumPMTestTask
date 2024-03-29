using Microsoft.EntityFrameworkCore;
using QuantumPMTestTask.Data;
using QuantumPMTestTask.Services;
public class NoteServiceTests
{
    private ApplicationDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            // Specifies that the database should be in-memory and have a unique name for each test
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    [Fact]
    public async Task GetAllNotesMethodReturnsAllNotes()
    {
        // Fill db with test values
        using var context = GetDbContext();
        var service = new NoteService(context);
        context.NotesList.Add(new NoteModel { NoteTitle = "Test Note 1", NoteText = "Test Content 1" });
        context.NotesList.Add(new NoteModel { NoteTitle = "Test Note 2", NoteText = "Test Content 2" });
        await context.SaveChangesAsync();

        // Trying to get all notes
        var notes = service.GetAllNotes();

        // Checking result
        Assert.Equal(2, notes.Count);
    }

    [Fact]
    public async Task GetByIdAsyncMethodReturnsCorrectNote()
    {
        // Fill db with test values
        using var context = GetDbContext();
        var service = new NoteService(context);
        var testNote = new NoteModel { NoteTitle = "Test Note", NoteText = "Test Content" };
        context.NotesList.Add(testNote);
        await context.SaveChangesAsync();

        // Trying to get note by id async
        var note = await service.GetByIdAsync(testNote.Id);

        // Checking result
        Assert.NotNull(note);
        Assert.Equal(testNote.NoteTitle, note.NoteTitle);
        Assert.Equal(testNote.NoteText, note.NoteText);
    }

    [Fact]
    public async Task UpdateMethodChangesNoteCorrectly()
    {
        // Fill db with test values
        using var context = GetDbContext();
        var service = new NoteService(context);
        var originalNote = new NoteModel { NoteTitle = "Original Title", NoteText = "Original Content" };
        context.NotesList.Add(originalNote);
        await context.SaveChangesAsync();
        // Fill new values
        var updatedNote = new NoteModel { Id = originalNote.Id, NoteTitle = "Updated Title", NoteText = "Updated Content" };

        // Trying to update
        var result = service.Update(updatedNote);
        var retrievedNote = await context.NotesList.FindAsync(originalNote.Id);

        // Checking result
        Assert.True(result);
        Assert.Equal(updatedNote.NoteTitle, retrievedNote.NoteTitle);
        Assert.Equal(updatedNote.NoteText, retrievedNote.NoteText);
    }

    [Fact]
    public async Task DeleteMethodRemovesNoteCorrectly()
    {
        // Fill db with test values
        using var context = GetDbContext();
        var service = new NoteService(context);
        var testNote = new NoteModel { NoteTitle = "Test Note", NoteText = "Test Content" };
        context.NotesList.Add(testNote);
        await context.SaveChangesAsync();

        // Trying to delete
        var result = service.Delete(testNote);
        var note = await context.NotesList.FindAsync(testNote.Id);

        // Checking result
        Assert.True(result);
        Assert.Null(note);
    }
}