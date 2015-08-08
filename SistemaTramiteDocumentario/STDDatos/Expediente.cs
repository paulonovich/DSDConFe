//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace STDDatos
{
    [DataContract(IsReference = false)]
    [KnownType(typeof(Cargo))]
    [KnownType(typeof(Solicitante))]
    [KnownType(typeof(Tramite))]
    public partial class Expediente
    {
        #region Primitive Properties
        [DataMember]
        public virtual int codigo
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> codigoSolicitante
        {
            get { return _codigoSolicitante; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_codigoSolicitante != value)
                    {
                        if (Solicitante != null && Solicitante.codigo != value)
                        {
                            Solicitante = null;
                        }
                        _codigoSolicitante = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _codigoSolicitante;
        [DataMember]
        public virtual Nullable<int> codigoTramite
        {
            get { return _codigoTramite; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_codigoTramite != value)
                    {
                        if (Tramite != null && Tramite.codigo != value)
                        {
                            Tramite = null;
                        }
                        _codigoTramite = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _codigoTramite;
        [DataMember]
        public virtual Nullable<int> Estado
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
        
    
        [DataMember]
        public virtual ICollection<Cargo> Cargoes
        {
            get
            {
                if (_cargoes == null)
                {
                    var newCollection = new FixupCollection<Cargo>();
                    newCollection.CollectionChanged += FixupCargoes;
                    _cargoes = newCollection;
                }
                return _cargoes;
            }
            set
            {
                if (!ReferenceEquals(_cargoes, value))
                {
                    var previousValue = _cargoes as FixupCollection<Cargo>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupCargoes;
                    }
                    _cargoes = value;
                    var newValue = value as FixupCollection<Cargo>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupCargoes;
                    }
                }
            }
        }
        private ICollection<Cargo> _cargoes;
        
    
        [DataMember]
        public virtual Solicitante Solicitante
        {
            get { return _solicitante; }
            set
            {
                if (!ReferenceEquals(_solicitante, value))
                {
                    var previousValue = _solicitante;
                    _solicitante = value;
                    FixupSolicitante(previousValue);
                }
            }
        }
        private Solicitante _solicitante;
        
    
        [DataMember]
        public virtual Tramite Tramite
        {
            get { return _tramite; }
            set
            {
                if (!ReferenceEquals(_tramite, value))
                {
                    var previousValue = _tramite;
                    _tramite = value;
                    FixupTramite(previousValue);
                }
            }
        }
        private Tramite _tramite;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupSolicitante(Solicitante previousValue)
        {
            if (previousValue != null && previousValue.Expedientes.Contains(this))
            {
                previousValue.Expedientes.Remove(this);
            }
    
            if (Solicitante != null)
            {
                if (!Solicitante.Expedientes.Contains(this))
                {
                    Solicitante.Expedientes.Add(this);
                }
                if (codigoSolicitante != Solicitante.codigo)
                {
                    codigoSolicitante = Solicitante.codigo;
                }
            }
            else if (!_settingFK)
            {
                codigoSolicitante = null;
            }
        }
    
        private void FixupTramite(Tramite previousValue)
        {
            if (previousValue != null && previousValue.Expedientes.Contains(this))
            {
                previousValue.Expedientes.Remove(this);
            }
    
            if (Tramite != null)
            {
                if (!Tramite.Expedientes.Contains(this))
                {
                    Tramite.Expedientes.Add(this);
                }
                if (codigoTramite != Tramite.codigo)
                {
                    codigoTramite = Tramite.codigo;
                }
            }
            else if (!_settingFK)
            {
                codigoTramite = null;
            }
        }
    
        private void FixupCargoes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Cargo item in e.NewItems)
                {
                    item.Expediente = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Cargo item in e.OldItems)
                {
                    if (ReferenceEquals(item.Expediente, this))
                    {
                        item.Expediente = null;
                    }
                }
            }
        }

        #endregion
    }
}
