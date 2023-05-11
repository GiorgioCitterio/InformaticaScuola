﻿namespace EsercizioMinApiFilm.Model;

public class Proiezione
{
    public int CinemaId { get; set; }
    public Cinema Cinema { get; set; }
    public int FilmId { get; set; }
    public Film Film { get; set; }
    public DateTime Data { get; set; }
    public int Ora { get; set; }
}