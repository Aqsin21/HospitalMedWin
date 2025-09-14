using Hospital.Business.Services.Abstract;
using Hospital.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Hospital.UI.Areas.Admin.Controllers
{
    public class NewsController : AdminController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async  Task<IActionResult> Index()
        {
            var news = await _newsService.GetAllAsync();
            return View(news);
        }

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(News news ,IFormFile? ImageFile)
        {
            if (!ModelState.IsValid) return View(news);
            if (await _newsService.ExistsAsync(n => n.Title == news.Title))
            {
                ModelState.AddModelError("Title", "This title with News Exist.");
                return View(news);
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                news.ImagePath = "/uploads/" + fileName;
            }
            else
            {
               
                ModelState.AddModelError("ImageFile", "Lütfen bir fotoğraf seçin.");
                return View(news);
            }

            await _newsService.CreateAsync(news);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var news = await _newsService.GetByIdAsync(id);
            if (news == null) return NotFound();
            return View(news);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(News news ,IFormFile? ImageFile)
        {
            if (!ModelState.IsValid) return View(news);

            var existingNews = await _newsService.GetByIdAsync(news.Id);

           
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                existingNews.ImagePath = "/uploads/" + fileName;
            }
            
            existingNews.Title = news.Title;
            existingNews.Description = news.Description;
            

            await _newsService.UpdateAsync(existingNews);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var news = await _newsService.GetByIdAsync(id);
            if (news == null) return NotFound();
            return View(news);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _newsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
        
    }

