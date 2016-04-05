using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AsdomiEF;



namespace requetesLinq
{
    delegate void RequeteLinq();
    public partial class FmReq : Form
    {
        private List<RequeteLinq> lesRequetes;
        asdomiEntities bd;
        public FmReq()
        {
            InitializeComponent();
            bd = new asdomiEntities();
            lesRequetes = new List<RequeteLinq>();
            listerRequetes();
        }
        private void listerRequetes()
        {
            cbRequete.Items.Add("requete0 : nom des patients");
            lesRequetes.Add(requete0);
            cbRequete.Items.Add("requete1 : nom, num SS et ville des patients");
            lesRequetes.Add(requete1);
            cbRequete.Items.Add("requete2 : liste des patients visités le 3 mai 2013, nés après 1920 triés par date de naissance et par nom");
            lesRequetes.Add(requete2);
            cbRequete.Items.Add("requete3 : nbre d'interventions par salarié, nb kms parcourus, temps passé ");
            lesRequetes.Add(requete3);
            cbRequete.Items.Add("requete4 : Liste des véhicules qui ont été utilisés plus de 2 fois");
            lesRequetes.Add(requete4);
            cbRequete.Items.Add("requete5: liste des patients qui n'ont jamais été visités");
            lesRequetes.Add(requete5);
        }
        private void btOk_Click(object sender, EventArgs e)
        {
            if (cbRequete.SelectedIndex != -1)
            {
                tbResultat.Clear();
                lesRequetes[cbRequete.SelectedIndex]();
            }

        }
        private void requete0()
        {
            //nom des patients
            var req = from patient in bd.patient
                      select patient.nomPatient;
            foreach (string nom in req)
            {
                this.tbResultat.AppendText(nom);
                tbResultat.AppendText(Environment.NewLine);
            }
        }
        private void requete1()
        {
            var rPatient = from pat in bd.patient
                           select new { pat.nomPatient, pat.numSS, pat.villePatient };
            
            foreach (var obj in rPatient.Distinct())
            {
                tbResultat.AppendText(obj.nomPatient + " " + obj.numSS + " " + obj.villePatient);
                tbResultat.AppendText(Environment.NewLine);
            } 


            
        }
        private void requete2()
        {
          // liste des patients visités le 3 mai 2013, nés après 1920 triés par date de naissance et par nom

        /*  var rPatient = from pat in bd.patient
                           from vis in bd.intervention
                           where pat.numSS == vis.numSS
                           && vis.dateIntervention.Equals(new DateTime(2013,05,03))
                           && pat.datenaissPatient.Value.Year > 1920
                           orderby pat.datenaissPatient, pat.nomPatient
                           select new { pat.numSS, pat.datenaissPatient,pat.nomPatient, pat.villePatient }; */
            var rPatient = bd.patient.Join(bd.intervention, p => p.numSS, i => i.numSS, (p, i) => new
            {
                p.numSS,
                p.datenaissPatient
                ,
                p.villePatient,
                p.nomPatient,
                i.dateIntervention
            }).Where(i => i.dateIntervention.Equals(new DateTime(2013, 5, 3)) &&
                    i.datenaissPatient.Value.Year > 1920).OrderBy(p => new { p.datenaissPatient, p.nomPatient });

            foreach (var obj in rPatient)
            {
                tbResultat.AppendText(obj.numSS + " " +  obj.datenaissPatient + " " +obj.nomPatient + " " + obj.villePatient);
                tbResultat.AppendText(Environment.NewLine);
            } 
        }

        private void requete3()
        {
            // nbre d'interventions par salarié, nb kms parcourus, temps passé

          /*  var rInter = from s in bd.salarie
                         from i in bd.intervention
                         where s.numSalarie == i.numSalarie
                         group i by new { s.nomSalarie }
                             into nbInter
                             let ni = nbInter.Count()
                             let km = nbInter.Sum(i => i.nbKm)
                             let t = nbInter.Sum(i => i.dureeIntervention)
                             select new
                             {
                                 nbInter.Key.nomSalarie,
                                 ni,
                                 km,
                                 t
                             };*/
            var rInter = bd.salarie.Join(bd.intervention, s => s.numSalarie, i => i.numSalarie, (s, i) => new
            {
                s.numSalarie,
                s.nomSalarie,
                i.dureeIntervention,
                i.nbKm
            }).GroupBy(n => new { n.numSalarie, n.nomSalarie }).Select(
            intervActivite => new
            {
                intervActivite.Key.numSalarie,
                intervActivite.Key.nomSalarie,
                nbkms = intervActivite.Sum(i => i.nbKm),
                temps = intervActivite.Sum(i => i.dureeIntervention)

            });

            

            foreach (var obj in rInter)
            {
                tbResultat.AppendText("le salarié " + obj.nomSalarie + " a parcouru " + obj.nbkms +
                    " avec un temps passe de " +obj.temps);
                tbResultat.AppendText(Environment.NewLine);
            } 
        }
        private void requete4()
        {
            //Liste des véhicules qui ont été utilisés plus de 2 fois

         /*   var rVehic = from v in bd.vehicule
                         from i in bd.intervention
                         where v.numVehicule == i.numVehicule
                         group i by new { v.numVehicule,v.noImmat }
                             into resultat
                             let r = resultat.Count()
                             where r > 2
                             select new
                             {
                                 resultat.Key.numVehicule,
                                 resultat.Key.noImmat,
                                 r
                             };*/
            var rVehic = bd.vehicule.Join(bd.intervention, v => v.numVehicule, i => i.numVehicule, (v, i) => new
            {
                v.numVehicule,
                v.noImmat
            }).GroupBy(i => new { i.numVehicule, i.noImmat }).Select(
            nbU => new
            {
                nbU.Key.numVehicule,
                nbU.Key.noImmat,
                nbu = nbU.Count()
            }).Where(u => u.nbu > 2);

            foreach (var obj in rVehic)
            {
                tbResultat.AppendText("le véhicule n° " + obj.numVehicule +" immatriculé " + obj.noImmat +" à été utilisé + de 2 fois");
                tbResultat.AppendText(Environment.NewLine);
            }                

        }
        private void requete5()
        {
            


          /*  var rVisit = from p in bd.patient
                         from i in bd.intervention
                         where p.numSS == i.numSS
                         select p;

            */

            var rVisit = bd.patient.Join(bd.intervention, p => p.numSS, i => i.numSS, (p, i) => p);

            var rNoVisit = bd.patient.ToList().Except(rVisit.ToList());

            foreach (var obj in rNoVisit)
            {
                tbResultat.AppendText("le patient " + obj.nomPatient+ " n'a pas été visité ");
                tbResultat.AppendText(Environment.NewLine);
            }                
                 
        }
    }
}

