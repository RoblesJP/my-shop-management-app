using AutoMapper;
using GestionForrajeria.Entities;
using GestionForrajeria.Models;
using GestionForrajeria.ViewModels.Mercaderia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionForrajeria.Controllers
{
    public class MercaderiaController : Controller
    {
        private readonly IMapper _mapper;
        public MercaderiaController(IMapper mapper) => _mapper = mapper;

        private MercaderiaRepository mercaderiaRepository = new MercaderiaRepository();

        public IActionResult Index()
        {
            List<Mercaderia> ListaMercaderiaDTO = mercaderiaRepository.GetAll();
            List<MercaderiaIndexViewModel> ListaMercaderiaViewModel = _mapper.Map<List<MercaderiaIndexViewModel>>(ListaMercaderiaDTO);
            return View(ListaMercaderiaViewModel);
        }

        public IActionResult CreateMercaderiaForm()
        {
            CreateMercaderiaViewModel createMercaderiaViewModel = new CreateMercaderiaViewModel()
            {
                Categorias = new List<SelectListItem>()
            };

            List<string> categorias = mercaderiaRepository.GetCategorias();
            foreach (string categoria in categorias)
            {
                createMercaderiaViewModel.Categorias.Add
                    (
                        new SelectListItem
                        {
                            Selected = false,
                            Text = categoria,
                            Value = (categorias.IndexOf(categoria) + 1).ToString()
                        }
                    );
            };

            return View(createMercaderiaViewModel);
        }

        [HttpPost]
        public IActionResult CreateMercaderia(CreateMercaderiaViewModel mercaderiaViewModel)
        {
            mercaderiaRepository.Insert(mercaderiaViewModel);
            return RedirectToAction("Index");
        }
    }
}
