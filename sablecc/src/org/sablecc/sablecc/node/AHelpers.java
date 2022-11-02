/* This file was generated by SableCC (http://www.sablecc.org/). */

package org.sablecc.sablecc.node;

import java.util.*;
import org.sablecc.sablecc.analysis.*;

public final class AHelpers extends PHelpers
{
    private final LinkedList _helper_defs_ = new TypedLinkedList(new HelperDefs_Cast());

    public AHelpers ()
    {
    }

    public AHelpers (
            List _helper_defs_
    )
    {
        this._helper_defs_.clear();
        this._helper_defs_.addAll(_helper_defs_);
    }

    public Object clone()
    {
        return new AHelpers (
            cloneList (_helper_defs_)
        );
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAHelpers(this);
    }

    public LinkedList getHelperDefs ()
    {
        return _helper_defs_;
    }

    public void setHelperDefs (List list)
    {
        _helper_defs_.clear();
        _helper_defs_.addAll(list);
    }

    public String toString()
    {
        return ""
            + toString (_helper_defs_)
        ;
    }

    void removeChild(Node child)
    {
        if ( _helper_defs_.remove(child))
        {
            return;
        }
    }

    void replaceChild(Node oldChild, Node newChild)
    {
        for(ListIterator i = _helper_defs_.listIterator(); i.hasNext();)
        {
            if(i.next() == oldChild)
            {
                if(newChild != null)
                {
                    i.set(newChild);
                    oldChild.parent(null);
                    return;
                }

                i.remove();
                oldChild.parent(null);
                return;
            }
        }
    }

    private class HelperDefs_Cast implements Cast
    {
        public Object cast(Object o)
        {
            PHelperDef node = (PHelperDef) o;

            if((node.parent() != null) &&
                (node.parent() != AHelpers.this))
            {
                node.parent().removeChild(node);
            }

            if((node.parent() == null) ||
                (node.parent() != AHelpers.this))
            {
                node.parent(AHelpers.this);
            }

            return node;
        }
    }
}
