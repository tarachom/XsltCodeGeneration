﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="text" indent="yes" />

  <xsl:param name="datetime" select="datetime" />
  
    <xsl:template match="/">
/*
 * Автоматично згенерований код 
 * Дата: <xsl:value-of select="$datetime"/>
 */

//Клас Test
//
public class Test
{
    public Test() { }
      <xsl:for-each select="root/fields/field">
    //<xsl:value-of select="comment"/>
    public <xsl:value-of select="type"/><xsl:text> </xsl:text><xsl:value-of select="name"/> { get; set; }
      </xsl:for-each>
}

    </xsl:template>
</xsl:stylesheet>