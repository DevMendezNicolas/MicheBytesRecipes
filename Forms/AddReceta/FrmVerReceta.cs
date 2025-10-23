using MicheBytesRecipes.Classes.Interacciones;
using MicheBytesRecipes.Managers;
using MicheBytesRecipes.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MicheBytesRecipes.Helpers;

namespace MicheBytesRecipes.Classes.Recetas
{

    public partial class FrmVerReceta : MaterialSkin.Controls.MaterialForm
    {
        private Receta receta;
        GestorReceta gestorReceta = new GestorReceta();
        GestorInteracciones gestorInteracciones = new GestorInteracciones();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();
        GestorIngredientes gestorIngredientes = new GestorIngredientes();
        private bool control = true; //Controla el estado del texto comentario
        private string comentarioUsuario; //Almacena el comentario del usuario
        private Usuario usuario; 

        public FrmVerReceta(Receta receta, Usuario usuarioLog)
        {
            InitializeComponent();
            GestorGrafico.AplicarTema(this);
            this.receta = receta;
            this.usuario = usuarioLog;


        }

        private void FrmVerReceta_Load(object sender, EventArgs e)
        {
            lblIdReceta.Visible = false;
            lblIdUsuario.Visible = false;
            gestorInteracciones.AgregarVisitaAlHistorial(receta.RecetaId, usuario.UsuarioId);

            CargarDatosReceta();

            txtComentario.Text = "Escribe un comentario...";
            txtComentario.ForeColor = Color.Gray; //Pone el texto en gris

            // Verificar si ya dio "Me Gusta"
            if(gestorInteracciones.TieneMeGusta(receta.RecetaId, usuario.UsuarioId))
            {
                btnMeGusta.Text = "❤️ Te gusta";
            }
            else
            {
                btnMeGusta.Text = "🤍 Me gusta";
            }
            if(gestorInteracciones.EstaFavorito(receta.RecetaId, usuario.UsuarioId))
            {
                btnFavoritos.Text = "❤️ Favorito";
            }
            else
            {
                btnFavoritos.Text = "🤍 Favorito";
            }

        }
        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMeGusta_Click(object sender, EventArgs e)
        {
            GestionMeGusta();
            ActualizarMeGusta();
        }
        private void btnFavoritos_Click(object sender, EventArgs e)
        {
            GestionFavorito();
        }

        // Metodo para cargar los datos de la receta en los controles del formulario
        private void CargarDatosReceta()
        {
            //Cargar los datos de la receta en los controles del formulario
            if (receta != null)
            {
                lblNombre.Text = receta.Nombre;
                lblDescripcion.Text = receta.Descripcion;
                lblDificultad.Text = receta.NivelDificultad.ToString();
                lblTiempo.Text = receta.TiempoPreparacion.ToString(@"hh\:mm");
                lblInstruccion.Text = receta.Instrucciones;

                //Cargar la imagen de la receta si existe
                if (receta.ImagenReceta != null && receta.ImagenReceta.Length > 0)
                {
                    //Crea una imagen a partir del arreglo de bytes
                    using (MemoryStream ms = new MemoryStream(receta.ImagenReceta))
                    {
                        //Se crea un objeto imagen a partir del stream
                        pbxImagen.Image = Image.FromStream(ms);
                        //Ajusta el tamaño de la imagen al tamaño del picturebox
                        pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pbxImagen.Image = null;
                }

                //Cargar los ingredientes en el listbox
                lstIngredientes.Items.Clear();
                if (receta.Ingredientes != null && receta.Ingredientes.Count > 0)
                {
                    foreach (var ingrediente in receta.Ingredientes)
                    {
                        lstIngredientes.Items.Add(ingrediente.Nombre);
                    }
                }else
                {
                    lstIngredientes.Items.Add("No hay ingredientes");
                }
                //Cargar la categoria y pais de la receta
                lblCategoria.Text = gestorCatalogo.ObtenerCategoriaPorId(receta.CategoriaId)?.Nombre ?? "Desconocida";
                lblPais.Text = gestorCatalogo.ObtenerPaisPorId(receta.PaisId)?.Nombre ?? "Desconocida";

                lblIdUsuario.Text = usuario.UsuarioId.ToString();
                lblIdReceta.Text = receta.RecetaId.ToString();

                CargarComentarios();
                ActualizarMeGusta();

            }
        }
        private void CargarComentarios()
        {
            lstComentarios.Items.Clear();
            GestorInteracciones gestorInteracciones = new GestorInteracciones();
            List<Comentarios> comentarios = gestorInteracciones.CargarComentarios(receta.RecetaId);

            if (comentarios != null && comentarios.Count > 0)
            {
                foreach (var comentario in comentarios)
                {
                    lstComentarios.Items.Add($"{comentario.NombreUsuario} ({comentario.FechaComentario:dd/MM/yyyy}): {comentario.Descripcion}");
                }
            }
            else
                lstComentarios.Items.Add("No hay comentarios");            
        }

        // Metodo para gestionar Interacciones
        private void GestionMeGusta()
        {
            int recetaId = receta.RecetaId;
            int usuarioId = usuario.UsuarioId;

            bool resultado = gestorInteracciones.GestionarMeGusta(recetaId, usuarioId);

            if (resultado)
            {
                //Si se agrego el me gusta 
                btnMeGusta.Text = "❤️ Te gusta";
                MessageBox.Show("¡Te gustó la receta!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Si se elimino el me gusta
                btnMeGusta.Text = "🤍 Me gusta";
                MessageBox.Show("Quitaste el me gusta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void ActualizarMeGusta()
        {
            int cantidad = gestorInteracciones.ContarMeGusta(receta.RecetaId);

            if(cantidad >= 0)
            {
                lblMeGusta.Text = cantidad.ToString();
            }else
            {
                lblMeGusta.Text = "Error";
            }
        }
        private void GestionFavorito()
        {
            int recetaId = receta.RecetaId;
            int usuarioId = usuario.UsuarioId;

            bool resultado = gestorInteracciones.GestionarFavoritos(recetaId, usuarioId);

            if (resultado)
            {
                // Se agrego a favoritos
                btnFavoritos.Text = "❤️ Favorito";
                MessageBox.Show("¡Receta agregada a favoritos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Se elimino de favoritos
                btnFavoritos.Text = "🤍 Favorito";
                MessageBox.Show("Receta eliminada de favoritos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Metodos para gestionar el cuadro de texto del comentario
        private void txtComentario_Enter(object sender, EventArgs e)
        {
            if (control)
            {
                txtComentario.Text = "";
                txtComentario.ForeColor = Color.Black; //Cambia el color del texto a negro
                control = false; //Cambia el estado del control para que no vuelva a entrar
            }
        }
        private void txtComentario_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtComentario.Text))
            {
                txtComentario.Text = "Escribe un comentario...";
                txtComentario.ForeColor = Color.Gray; //Pone el texto en gris
                control = true; //Cambia el estado del control para que vuelva a entrar
            }
        }
        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter) //Si se presiona la tecla Enter
            {
                e.Handled = true; //Asegura que no se agregue una nueva linea

                if(!control && !string.IsNullOrWhiteSpace(txtComentario.Text))
                {
                    // Asigna el comentario del usuario a la variable
                    comentarioUsuario = txtComentario.Text;

                    // Crear un nuevo objeto Comentarios
                    Comentarios nuevoComentario = new Comentarios
                    {
                        Descripcion = comentarioUsuario,
                        RecetaId = int.Parse(lblIdReceta.Text),
                        UsuarioId = int.Parse(lblIdUsuario.Text)
                    };

                    // Guardar el comentario usando el gestor de interacciones
                    GestorInteracciones gestorInteracciones = new GestorInteracciones();
                    // Intentar agregar el comentario y mostrar un mensaje según el resultado
                    bool exito = gestorInteracciones.AgregarComentario(nuevoComentario);
                    // Mostrar mensaje de éxito o error
                    if (exito)
                    {
                        MessageBox.Show("Comentario agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtComentario.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el comentario. Inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //Restablecer el cuadro de texto
                    control = true;
                    txtComentario_Leave(sender, EventArgs.Empty); //Llama al metodo Leave para restaurar el texto

                    CargarComentarios();
                                                                 
                }
            }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            TimeSpan tiempo = TimeSpan.Parse(lblTiempo.Text);
            List<string> ingredientes = new List<string>();

            foreach(var ingrendiente in lstIngredientes.Items)
            {
                ingredientes.Add(ingrendiente.ToString());
            }

            using (MemoryStream ms = new MemoryStream())
            {
                //pbxImagen.Image.Save(ms, pbxImagen.Image.RawFormat); // Guarda en el formato original
                //byte[] foto = ms.ToArray();
                GeneradorPdf.ExportarRecetaAPdf(lblNombre.Text, lblDescripcion.Text, lblInstruccion.Text, null , ingredientes, lblPais.Text, lblCategoria.Text, lblDificultad.Text, tiempo);
            }

           

        }
    }
}
