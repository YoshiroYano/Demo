/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace ImageProcClient.Contracts
{

    public partial class imageProcService {
        /// <summary>
        /// The first thing to know about are types. The available types in Thrift are:
        /// 
        ///  bool        Boolean, one byte
        ///  i8 (byte)   Signed 8-bit integer
        ///  i16         Signed 16-bit integer
        ///  i32         Signed 32-bit integer
        ///  i64         Signed 64-bit integer
        ///  double      64-bit floating point value
        ///  string      String
        ///  binary      Blob (byte array)
        ///  map<t1,t2>  Map from one type to another
        ///  list<t1>    Ordered list of one type
        ///  set<t1>     Set of unique elements of one type
        /// 
        /// Did you also notice that Thrift supports C style comments?
        /// </summary>
        public interface ISync {
            byte[] Revert(byte[] image, int width, int height);
        }

        /// <summary>
        /// The first thing to know about are types. The available types in Thrift are:
        /// 
        ///  bool        Boolean, one byte
        ///  i8 (byte)   Signed 8-bit integer
        ///  i16         Signed 16-bit integer
        ///  i32         Signed 32-bit integer
        ///  i64         Signed 64-bit integer
        ///  double      64-bit floating point value
        ///  string      String
        ///  binary      Blob (byte array)
        ///  map<t1,t2>  Map from one type to another
        ///  list<t1>    Ordered list of one type
        ///  set<t1>     Set of unique elements of one type
        /// 
        /// Did you also notice that Thrift supports C style comments?
        /// </summary>
        public interface Iface : ISync {
#if SILVERLIGHT
    IAsyncResult Begin_Revert(AsyncCallback callback, object state, byte[] image, int width, int height);
    byte[] End_Revert(IAsyncResult asyncResult);
    #endif
        }

        /// <summary>
        /// The first thing to know about are types. The available types in Thrift are:
        /// 
        ///  bool        Boolean, one byte
        ///  i8 (byte)   Signed 8-bit integer
        ///  i16         Signed 16-bit integer
        ///  i32         Signed 32-bit integer
        ///  i64         Signed 64-bit integer
        ///  double      64-bit floating point value
        ///  string      String
        ///  binary      Blob (byte array)
        ///  map<t1,t2>  Map from one type to another
        ///  list<t1>    Ordered list of one type
        ///  set<t1>     Set of unique elements of one type
        /// 
        /// Did you also notice that Thrift supports C style comments?
        /// </summary>
        public class Client : IDisposable, Iface {
            public Client(TProtocol prot) : this(prot, prot)
            {
            }

            public Client(TProtocol iprot, TProtocol oprot)
            {
                this.iprot_ = iprot;
                this.oprot_ = oprot;
            }

            protected TProtocol iprot_;
            protected TProtocol oprot_;
            protected int seqid_;

            public TProtocol InputProtocol
            {
                get { return this.iprot_; }
            }
            public TProtocol OutputProtocol
            {
                get { return this.oprot_; }
            }


            #region " IDisposable Support "
            private bool _IsDisposed;

            // IDisposable
            public void Dispose()
            {
                this.Dispose(true);
            }
    

            protected virtual void Dispose(bool disposing)
            {
                if (!this._IsDisposed)
                {
                    if (disposing)
                    {
                        if (this.iprot_ != null)
                        {
                            ((IDisposable)this.iprot_).Dispose();
                        }
                        if (this.oprot_ != null)
                        {
                            ((IDisposable)this.oprot_).Dispose();
                        }
                    }
                }
                this._IsDisposed = true;
            }
            #endregion


    
#if SILVERLIGHT
    public IAsyncResult Begin_Revert(AsyncCallback callback, object state, byte[] image, int width, int height)
    {
      return send_Revert(callback, state, image, width, height);
    }

    public byte[] End_Revert(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_Revert();
    }

    #endif

            public byte[] Revert(byte[] image, int width, int height)
            {
#if !SILVERLIGHT
                this.send_Revert(image, width, height);
                return this.recv_Revert();

#else
      var asyncResult = Begin_Revert(null, null, image, width, height);
      return End_Revert(asyncResult);

      #endif
            }
#if SILVERLIGHT
    public IAsyncResult send_Revert(AsyncCallback callback, object state, byte[] image, int width, int height)
    #else
            public void send_Revert(byte[] image, int width, int height)
#endif
            {
                this.oprot_.WriteMessageBegin(new TMessage("Revert", TMessageType.Call, this.seqid_));
                Revert_args args = new Revert_args();
                args.Image = image;
                args.Width = width;
                args.Height = height;
                args.Write(this.oprot_);
                this.oprot_.WriteMessageEnd();
#if SILVERLIGHT
      return oprot_.Transport.BeginFlush(callback, state);
      #else
                this.oprot_.Transport.Flush();
#endif
            }

            public byte[] recv_Revert()
            {
                TMessage msg = this.iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception) {
                    TApplicationException x = TApplicationException.Read(this.iprot_);
                    this.iprot_.ReadMessageEnd();
                    throw x;
                }
                Revert_result result = new Revert_result();
                result.Read(this.iprot_);
                this.iprot_.ReadMessageEnd();
                if (result.__isset.success) {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "Revert failed: unknown result");
            }

        }
        public class Processor : TProcessor {
            public Processor(ISync iface)
            {
                this.iface_ = iface;
                this.processMap_["Revert"] = this.Revert_Process;
            }

            protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
            private ISync iface_;
            protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

            public bool Process(TProtocol iprot, TProtocol oprot)
            {
                try
                {
                    TMessage msg = iprot.ReadMessageBegin();
                    ProcessFunction fn;
                    this.processMap_.TryGetValue(msg.Name, out fn);
                    if (fn == null) {
                        TProtocolUtil.Skip(iprot, TType.Struct);
                        iprot.ReadMessageEnd();
                        TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
                        oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
                        x.Write(oprot);
                        oprot.WriteMessageEnd();
                        oprot.Transport.Flush();
                        return true;
                    }
                    fn(msg.SeqID, iprot, oprot);
                }
                catch (IOException)
                {
                    return false;
                }
                return true;
            }

            public void Revert_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Revert_args args = new Revert_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                Revert_result result = new Revert_result();
                try
                {
                    result.Success = this.iface_.Revert(args.Image, args.Width, args.Height);
                    oprot.WriteMessageBegin(new TMessage("Revert", TMessageType.Reply, seqid)); 
                    result.Write(oprot);
                }
                catch (TTransportException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error occurred in processor:");
                    Console.Error.WriteLine(ex.ToString());
                    TApplicationException x = new TApplicationException      (TApplicationException.ExceptionType.InternalError," Internal error.");
                    oprot.WriteMessageBegin(new TMessage("Revert", TMessageType.Exception, seqid));
                    x.Write(oprot);
                }
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class Revert_args : TBase
        {
            private byte[] _image;
            private int _width;
            private int _height;

            public byte[] Image
            {
                get
                {
                    return this._image;
                }
                set
                {
                    this.__isset.image = true;
                    this._image = value;
                }
            }

            public int Width
            {
                get
                {
                    return this._width;
                }
                set
                {
                    this.__isset.width = true;
                    this._width = value;
                }
            }

            public int Height
            {
                get
                {
                    return this._height;
                }
                set
                {
                    this.__isset.height = true;
                    this._height = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset {
                public bool image;
                public bool width;
                public bool height;
            }

            public Revert_args() {
            }

            public void Read (TProtocol iprot)
            {
                iprot.IncrementRecursionDepth();
                try
                {
                    TField field;
                    iprot.ReadStructBegin();
                    while (true)
                    {
                        field = iprot.ReadFieldBegin();
                        if (field.Type == TType.Stop) { 
                            break;
                        }
                        switch (field.ID)
                        {
                            case 1:
                                if (field.Type == TType.String) {
                                    this.Image = iprot.ReadBinary();
                                } else { 
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            case 2:
                                if (field.Type == TType.I32) {
                                    this.Width = iprot.ReadI32();
                                } else { 
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            case 3:
                                if (field.Type == TType.I32) {
                                    this.Height = iprot.ReadI32();
                                } else { 
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            default: 
                                TProtocolUtil.Skip(iprot, field.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    iprot.ReadStructEnd();
                }
                finally
                {
                    iprot.DecrementRecursionDepth();
                }
            }

            public void Write(TProtocol oprot) {
                oprot.IncrementRecursionDepth();
                try
                {
                    TStruct struc = new TStruct("Revert_args");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (this.Image != null && this.__isset.image) {
                        field.Name = "image";
                        field.Type = TType.String;
                        field.ID = 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteBinary(this.Image);
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.width) {
                        field.Name = "width";
                        field.Type = TType.I32;
                        field.ID = 2;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Width);
                        oprot.WriteFieldEnd();
                    }
                    if (this.__isset.height) {
                        field.Name = "height";
                        field.Type = TType.I32;
                        field.ID = 3;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI32(this.Height);
                        oprot.WriteFieldEnd();
                    }
                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }

            public override string ToString() {
                StringBuilder __sb = new StringBuilder("Revert_args(");
                bool __first = true;
                if (this.Image != null && this.__isset.image) {
                    if(!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("Image: ");
                    __sb.Append(this.Image);
                }
                if (this.__isset.width) {
                    if(!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("Width: ");
                    __sb.Append(this.Width);
                }
                if (this.__isset.height) {
                    if(!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("Height: ");
                    __sb.Append(this.Height);
                }
                __sb.Append(")");
                return __sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class Revert_result : TBase
        {
            private byte[] _success;

            public byte[] Success
            {
                get
                {
                    return this._success;
                }
                set
                {
                    this.__isset.success = true;
                    this._success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset {
                public bool success;
            }

            public Revert_result() {
            }

            public void Read (TProtocol iprot)
            {
                iprot.IncrementRecursionDepth();
                try
                {
                    TField field;
                    iprot.ReadStructBegin();
                    while (true)
                    {
                        field = iprot.ReadFieldBegin();
                        if (field.Type == TType.Stop) { 
                            break;
                        }
                        switch (field.ID)
                        {
                            case 0:
                                if (field.Type == TType.String) {
                                    this.Success = iprot.ReadBinary();
                                } else { 
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            default: 
                                TProtocolUtil.Skip(iprot, field.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    iprot.ReadStructEnd();
                }
                finally
                {
                    iprot.DecrementRecursionDepth();
                }
            }

            public void Write(TProtocol oprot) {
                oprot.IncrementRecursionDepth();
                try
                {
                    TStruct struc = new TStruct("Revert_result");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();

                    if (this.__isset.success) {
                        if (this.Success != null) {
                            field.Name = "Success";
                            field.Type = TType.String;
                            field.ID = 0;
                            oprot.WriteFieldBegin(field);
                            oprot.WriteBinary(this.Success);
                            oprot.WriteFieldEnd();
                        }
                    }
                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }

            public override string ToString() {
                StringBuilder __sb = new StringBuilder("Revert_result(");
                bool __first = true;
                if (this.Success != null && this.__isset.success) {
                    if(!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("Success: ");
                    __sb.Append(this.Success);
                }
                __sb.Append(")");
                return __sb.ToString();
            }

        }

    }

}