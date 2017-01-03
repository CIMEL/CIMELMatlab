/*
* MATLAB Compiler: 4.17 (R2012a)
* Date: Tue Jan 03 01:25:01 2017
* Arguments: "-B" "macro_default" "-W" "dotnet:CIMELDraw,Drawing,4.0," "-T" "link:lib"
* "-d" "F:\Projects\Peach\CIMELMatlab\src" "-w" "enable:specified_file_mismatch" "-w"
* "enable:repeated_file" "-w" "enable:switch_ignored" "-w" "enable:missing_lib_sentinel"
* "-w" "enable:demo_license" "-v"
* "class{Drawing:F:\Projects\Peach\CIMELMatlab\MatrixCIMEL.m}" 
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
  /// F:\Projects\Peach\CIMELMatlab\MatrixCIMEL.m
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
