package com.emids.da;

import com.monitorjbl.xlsx.StreamingReader;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.ss.usermodel.Workbook;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

public class ProjectMaster {
  public static void main(String[] args) throws IOException {
    InputStream is =
      new FileInputStream(
        new File(
          "/home/samanth/Work/emids/projects/daportal/docs/Requirements/Project Master.xlsx"));
    Workbook workbook = StreamingReader.builder().rowCacheSize(100).bufferSize(4096).open(is);

    for (Sheet sheet : workbook) {
      System.out.println(sheet.getSheetName() + " ====================");
      for (Row r : sheet) {
        for (Cell c : r) {
          System.out.println(c.getStringCellValue());
        }
      }
    }
  }
}
