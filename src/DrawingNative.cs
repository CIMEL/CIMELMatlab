/*
* MATLAB Compiler: 4.17 (R2012a)
* Date: Sun Dec 25 23:14:02 2016
* Arguments: "-B" "macro_default" "-W" "dotnet:CIMELDraw,Drawing,4.0," "-T" "link:lib"
* "-d" "E:\AeronetInversion\AeronetDraw\src" "-w" "enable:specified_file_mismatch" "-w"
* "enable:repeated_file" "-w" "enable:switch_ignored" "-w" "enable:missing_lib_sentinel"
* "-w" "enable:demo_license" "-v"
* "class{Drawing:E:\AeronetInversion\AeronetDraw\DrawCIMELInversions.m,E:\AeronetInversion
* \AeronetDraw\DrawSSA.m,E:\AeronetInversion\AeronetDraw\DrawSSAStatistisc.m,E:\AeronetInv
* ersion\AeronetDraw\MatrixCIMEL.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace CIMELDrawNative
{

  /// <summary>
  /// The Drawing class provides a CLS compliant, Object (native) interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// E:\AeronetInversion\AeronetDraw\DrawCIMELInversions.m
  /// <newpara></newpara>
  /// E:\AeronetInversion\AeronetDraw\DrawSSA.m
  /// <newpara></newpara>
  /// E:\AeronetInversion\AeronetDraw\DrawSSAStatistisc.m
  /// <newpara></newpara>
  /// E:\AeronetInversion\AeronetDraw\MatrixCIMEL.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 4.0
  /// </remarks>
  public class Drawing : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static Drawing()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        string ctfFileName = "CIMELDraw.ctf";

        Stream embeddedCtfStream = null;

        String[] resourceStrings = assembly.GetManifestResourceNames();

        foreach (String name in resourceStrings)
        {
          if (name.Contains(ctfFileName))
          {
            embeddedCtfStream = assembly.GetManifestResourceStream(name);
            break;
          }
        }
        mcr= new MWMCR("",
                       ctfFilePath, embeddedCtfStream, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Drawing class.
    /// </summary>
    public Drawing()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Drawing()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the DrawCIMELInversions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// eval(['print -dtiff e:\qa\Research_result\Ulumqi_cimel\fig_aeronet_inversion_'
    /// num2str(yy) strmm(mm,:) strdd(dd,:) '.tiff']);
    /// </remarks>
    ///
    public void DrawCIMELInversions()
    {
      mcr.EvaluateFunction(0, "DrawCIMELInversions", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the DrawCIMELInversions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// eval(['print -dtiff e:\qa\Research_result\Ulumqi_cimel\fig_aeronet_inversion_'
    /// num2str(yy) strmm(mm,:) strdd(dd,:) '.tiff']);
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    ///
    public void DrawCIMELInversions(Object stats_inversion)
    {
      mcr.EvaluateFunction(0, "DrawCIMELInversions", stats_inversion);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the DrawCIMELInversions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// eval(['print -dtiff e:\qa\Research_result\Ulumqi_cimel\fig_aeronet_inversion_'
    /// num2str(yy) strmm(mm,:) strdd(dd,:) '.tiff']);
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    ///
    public void DrawCIMELInversions(Object stats_inversion, Object r)
    {
      mcr.EvaluateFunction(0, "DrawCIMELInversions", stats_inversion, r);
    }


    /// <summary>
    /// Provides a void output, 3-input Objectinterface to the DrawCIMELInversions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// eval(['print -dtiff e:\qa\Research_result\Ulumqi_cimel\fig_aeronet_inversion_'
    /// num2str(yy) strmm(mm,:) strdd(dd,:) '.tiff']);
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="outputbase">Input argument #3</param>
    ///
    public void DrawCIMELInversions(Object stats_inversion, Object r, Object outputbase)
    {
      mcr.EvaluateFunction(0, "DrawCIMELInversions", stats_inversion, r, outputbase);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the DrawCIMELInversions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// eval(['print -dtiff e:\qa\Research_result\Ulumqi_cimel\fig_aeronet_inversion_'
    /// num2str(yy) strmm(mm,:) strdd(dd,:) '.tiff']);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawCIMELInversions(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawCIMELInversions", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the DrawCIMELInversions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// eval(['print -dtiff e:\qa\Research_result\Ulumqi_cimel\fig_aeronet_inversion_'
    /// num2str(yy) strmm(mm,:) strdd(dd,:) '.tiff']);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawCIMELInversions(int numArgsOut, Object stats_inversion)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawCIMELInversions", stats_inversion);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the DrawCIMELInversions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// eval(['print -dtiff e:\qa\Research_result\Ulumqi_cimel\fig_aeronet_inversion_'
    /// num2str(yy) strmm(mm,:) strdd(dd,:) '.tiff']);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawCIMELInversions(int numArgsOut, Object stats_inversion, Object r)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawCIMELInversions", stats_inversion, r);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the DrawCIMELInversions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// eval(['print -dtiff e:\qa\Research_result\Ulumqi_cimel\fig_aeronet_inversion_'
    /// num2str(yy) strmm(mm,:) strdd(dd,:) '.tiff']);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="outputbase">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawCIMELInversions(int numArgsOut, Object stats_inversion, Object r, 
                                  Object outputbase)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawCIMELInversions", stats_inversion, r, outputbase);
    }


    /// <summary>
    /// Provides an interface for the DrawCIMELInversions function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// eval(['print -dtiff e:\qa\Research_result\Ulumqi_cimel\fig_aeronet_inversion_'
    /// num2str(yy) strmm(mm,:) strdd(dd,:) '.tiff']);
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("DrawCIMELInversions", 3, 0, 0)]
    protected void DrawCIMELInversions(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("DrawCIMELInversions", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    ///
    public void DrawSSA()
    {
      mcr.EvaluateFunction(0, "DrawSSA", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    ///
    public void DrawSSA(Object stats_inversion)
    {
      mcr.EvaluateFunction(0, "DrawSSA", stats_inversion);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    ///
    public void DrawSSA(Object stats_inversion, Object r)
    {
      mcr.EvaluateFunction(0, "DrawSSA", stats_inversion, r);
    }


    /// <summary>
    /// Provides a void output, 3-input Objectinterface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    ///
    public void DrawSSA(Object stats_inversion, Object r, Object year)
    {
      mcr.EvaluateFunction(0, "DrawSSA", stats_inversion, r, year);
    }


    /// <summary>
    /// Provides a void output, 4-input Objectinterface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <param name="region">Input argument #4</param>
    ///
    public void DrawSSA(Object stats_inversion, Object r, Object year, Object region)
    {
      mcr.EvaluateFunction(0, "DrawSSA", stats_inversion, r, year, region);
    }


    /// <summary>
    /// Provides a void output, 5-input Objectinterface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <param name="region">Input argument #4</param>
    /// <param name="outputbase">Input argument #5</param>
    ///
    public void DrawSSA(Object stats_inversion, Object r, Object year, Object region, 
                  Object outputbase)
    {
      mcr.EvaluateFunction(0, "DrawSSA", stats_inversion, r, year, region, outputbase);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSA(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSA", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSA(int numArgsOut, Object stats_inversion)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSA", stats_inversion);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSA(int numArgsOut, Object stats_inversion, Object r)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSA", stats_inversion, r);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSA(int numArgsOut, Object stats_inversion, Object r, Object year)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSA", stats_inversion, r, year);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <param name="region">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSA(int numArgsOut, Object stats_inversion, Object r, Object 
                      year, Object region)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSA", stats_inversion, r, year, region);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the DrawSSA M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <param name="region">Input argument #4</param>
    /// <param name="outputbase">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSA(int numArgsOut, Object stats_inversion, Object r, Object 
                      year, Object region, Object outputbase)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSA", stats_inversion, r, year, region, outputbase);
    }


    /// <summary>
    /// Provides an interface for the DrawSSA function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// ssa月平均
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("DrawSSA", 5, 0, 0)]
    protected void DrawSSA(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("DrawSSA", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    ///
    public void DrawSSAStatistisc()
    {
      mcr.EvaluateFunction(0, "DrawSSAStatistisc", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    ///
    public void DrawSSAStatistisc(Object stats_inversion)
    {
      mcr.EvaluateFunction(0, "DrawSSAStatistisc", stats_inversion);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    ///
    public void DrawSSAStatistisc(Object stats_inversion, Object r)
    {
      mcr.EvaluateFunction(0, "DrawSSAStatistisc", stats_inversion, r);
    }


    /// <summary>
    /// Provides a void output, 3-input Objectinterface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    ///
    public void DrawSSAStatistisc(Object stats_inversion, Object r, Object year)
    {
      mcr.EvaluateFunction(0, "DrawSSAStatistisc", stats_inversion, r, year);
    }


    /// <summary>
    /// Provides a void output, 4-input Objectinterface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <param name="region">Input argument #4</param>
    ///
    public void DrawSSAStatistisc(Object stats_inversion, Object r, Object year, Object 
                            region)
    {
      mcr.EvaluateFunction(0, "DrawSSAStatistisc", stats_inversion, r, year, region);
    }


    /// <summary>
    /// Provides a void output, 5-input Objectinterface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <param name="region">Input argument #4</param>
    /// <param name="outputbase">Input argument #5</param>
    ///
    public void DrawSSAStatistisc(Object stats_inversion, Object r, Object year, Object 
                            region, Object outputbase)
    {
      mcr.EvaluateFunction(0, "DrawSSAStatistisc", stats_inversion, r, year, region, outputbase);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSAStatistisc(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSAStatistisc", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSAStatistisc(int numArgsOut, Object stats_inversion)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSAStatistisc", stats_inversion);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSAStatistisc(int numArgsOut, Object stats_inversion, Object r)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSAStatistisc", stats_inversion, r);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSAStatistisc(int numArgsOut, Object stats_inversion, Object r, 
                                Object year)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSAStatistisc", stats_inversion, r, year);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <param name="region">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSAStatistisc(int numArgsOut, Object stats_inversion, Object r, 
                                Object year, Object region)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSAStatistisc", stats_inversion, r, year, region);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the DrawSSAStatistisc
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="stats_inversion">Input argument #1</param>
    /// <param name="r">Input argument #2</param>
    /// <param name="year">Input argument #3</param>
    /// <param name="region">Input argument #4</param>
    /// <param name="outputbase">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] DrawSSAStatistisc(int numArgsOut, Object stats_inversion, Object r, 
                                Object year, Object region, Object outputbase)
    {
      return mcr.EvaluateFunction(numArgsOut, "DrawSSAStatistisc", stats_inversion, r, year, region, outputbase);
    }


    /// <summary>
    /// Provides an interface for the DrawSSAStatistisc function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 绘图
    /// ssa
    /// figure;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("DrawSSAStatistisc", 5, 0, 0)]
    protected void DrawSSAStatistisc(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("DrawSSAStatistisc", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object MatrixCIMEL()
    {
      return mcr.EvaluateFunction("MatrixCIMEL", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="lat">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object MatrixCIMEL(Object lat)
    {
      return mcr.EvaluateFunction("MatrixCIMEL", lat);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="lat">Input argument #1</param>
    /// <param name="lon">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object MatrixCIMEL(Object lat, Object lon)
    {
      return mcr.EvaluateFunction("MatrixCIMEL", lat, lon);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="lat">Input argument #1</param>
    /// <param name="lon">Input argument #2</param>
    /// <param name="input">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object MatrixCIMEL(Object lat, Object lon, Object input)
    {
      return mcr.EvaluateFunction("MatrixCIMEL", lat, lon, input);
    }


    /// <summary>
    /// Provides a single output, 4-input Objectinterface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="lat">Input argument #1</param>
    /// <param name="lon">Input argument #2</param>
    /// <param name="input">Input argument #3</param>
    /// <param name="outputfile">Input argument #4</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object MatrixCIMEL(Object lat, Object lon, Object input, Object outputfile)
    {
      return mcr.EvaluateFunction("MatrixCIMEL", lat, lon, input, outputfile);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] MatrixCIMEL(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "MatrixCIMEL", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="lat">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] MatrixCIMEL(int numArgsOut, Object lat)
    {
      return mcr.EvaluateFunction(numArgsOut, "MatrixCIMEL", lat);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="lat">Input argument #1</param>
    /// <param name="lon">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] MatrixCIMEL(int numArgsOut, Object lat, Object lon)
    {
      return mcr.EvaluateFunction(numArgsOut, "MatrixCIMEL", lat, lon);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="lat">Input argument #1</param>
    /// <param name="lon">Input argument #2</param>
    /// <param name="input">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] MatrixCIMEL(int numArgsOut, Object lat, Object lon, Object input)
    {
      return mcr.EvaluateFunction(numArgsOut, "MatrixCIMEL", lat, lon, input);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the MatrixCIMEL M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="lat">Input argument #1</param>
    /// <param name="lon">Input argument #2</param>
    /// <param name="input">Input argument #3</param>
    /// <param name="outputfile">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] MatrixCIMEL(int numArgsOut, Object lat, Object lon, Object input, 
                          Object outputfile)
    {
      return mcr.EvaluateFunction(numArgsOut, "MatrixCIMEL", lat, lon, input, outputfile);
    }


    /// <summary>
    /// Provides an interface for the MatrixCIMEL function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 读取AERONET反演产品
    /// lat: the lat of the region
    /// lon: the lot of the region
    /// input: the base input folder of region
    /// outputfile: the outputfile
    /// clear;
    /// move to arg
    /// stns_fn='hangzhou';
    /// move to arg
    /// stns_id='808';
    /// YearInCount=2013;
    /// fout=['h:\CARSNET_INVERSION\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// fout=['E:\development\CIMEL_NETWORK\' stns_fn '\dubovik\'];
    /// move the initial logic to C#
    /// fout=output;
    /// if ~exist(fout,'dir')
    /// mkdir(fout);
    /// end
    /// fpath=['E:\QA\AERONET_INVERSION\output\' stns_fn '\'];
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("MatrixCIMEL", 4, 2, 0)]
    protected void MatrixCIMEL(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("MatrixCIMEL", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
