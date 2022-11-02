/* This file was generated by SableCC (http://www.sablecc.org/). */

package org.sablecc.sablecc.xss2.node;

import org.sablecc.sablecc.xss2.analysis.*;

public final class TXcurrent extends Token
{
    public TXcurrent()
    {
        super.setText(".");
    }

    public TXcurrent(int line, int pos)
    {
        super.setText(".");
        setLine(line);
        setPos(pos);
    }

    public Object clone()
    {
      return new TXcurrent(getLine(), getPos());
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTXcurrent(this);
    }

    public void setText(String text)
    {
        throw new RuntimeException("Cannot change TXcurrent text.");
    }
}
