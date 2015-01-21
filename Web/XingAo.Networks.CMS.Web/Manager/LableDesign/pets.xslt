<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html"/>
  <xsl:template match="/">
    <ul>
          <xsl:for-each select="bookstore/book">
            <li>
                <xsl:value-of select="title"/>
                <xsl:value-of select="price"/>
                <xsl:value-of select="zk"/>
            </li>
          </xsl:for-each>
    </ul>
  </xsl:template>
</xsl:stylesheet>
