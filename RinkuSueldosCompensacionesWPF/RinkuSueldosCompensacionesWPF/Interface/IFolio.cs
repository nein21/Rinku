using RinkuSueldosCompensacionesWPF.Model;

namespace RinkuSueldosCompensacionesWPF.Interface
{
    interface IFolio
    {
        void obtieneUltimoFolio(int id);
        void agregaFolio(CapturaFolio f);
        void buscaFolio(int id);        
        void modificaFolio(CapturaFolio f);
        void eliminaFolio(int id);
    }
}
