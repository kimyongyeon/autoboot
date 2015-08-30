using System;
using System.Collections.Generic;
using System.Text;

// 형선언
using uint16_t = System.UInt32;
using uint8_t = System.UInt16;

namespace WindowsApplication1
{
    class CreateRFMessages
    {
        #region 전문 관련 정의
        // 전문
        private const int RF_MSG_SIZE = 42;
        private const int RF_DATA_MSG_SIZE = 25;

        enum DEF_RF_MSG
        {
            SYNC_BYTE = 0x7e,
            ESCAPE_BYTE = 0x7d,
            P_ACK = 64,
            P_PACKET_ACK = 65,
            P_PACKET_NO_ACK = 66,
            P_UNKNOWN = 255,

            ADDR_BROADCAST = 0xFF
        };
        
        public static byte[] escaped = new byte[RF_MSG_SIZE];
        private static int escapeptr;
        private static uint16_t crc;

        #endregion

        public byte[] create_framed_packet(uint8_t _seqno, uint8_t _nodeId, string Msg)
        {
            uint16_t tm_crc;
            int i, count;

            escapeptr = 0;
            tm_crc = 0;

            try
            {
                // 값 대입
                checked
                {
                    escaped[escapeptr++] = System.Convert.ToByte(DEF_RF_MSG.SYNC_BYTE);         // 0

                    escape_byte(System.Convert.ToUInt16(DEF_RF_MSG.P_PACKET_ACK));              // 1
                    escape_byte(_seqno);                                                        // 2 -> seqno

                    escape_byte(System.Convert.ToUInt16(DEF_RF_MSG.ADDR_BROADCAST));            // 3 : 브로드캐스트
                    escape_byte(System.Convert.ToUInt16(DEF_RF_MSG.ADDR_BROADCAST));            // 4
                    escape_byte(0);                                                             // 5
                    escape_byte(0);                                                             // 6 : 그룹
                    escape_byte(0x1d);                                                          // 7 : 길이
                    
                    escape_byte(_nodeId);                                                       // 8 : node ID

                    escape_byte(0);                                                             // 9
                    escape_byte(0);                                                             // 10
                    escape_byte(0);                                                             // 11

                    // data 12 ~35
                    // 전문 체크 및 자르기
                    // 우선 전문 최고 길이만 전송 -> 수정해야함 에러처리 길어질 경우
                    char[] sMsg = Msg.ToCharArray();
                    count = sMsg.Length;

                    // 전문 길이 비교
                    // 허용 길이 내의 전문
                    if (RF_DATA_MSG_SIZE >= count)
                    {
                        for (i = 0; i < count; i++)
                        {
                            escape_byte(sMsg[i]);
                        }

                        // 전문의 길이가 작을 경우
                        if (RF_DATA_MSG_SIZE != count)
                        {
                            for (i = count; i < RF_DATA_MSG_SIZE; i++)
                                escape_byte(0);
                        }
                    }
                    else
                    {
                        // 에러처리
                    }
                                        
                    tm_crc = crc;
                    
                    escape_byte(System.Convert.ToUInt16(tm_crc & 0xff));
                    escape_byte(System.Convert.ToUInt16(tm_crc >> 8));                  
                }
            }
            catch (Exception e)
            {
                //throw e;
            }
            finally
            {
                escaped[escapeptr++] = System.Convert.ToByte(DEF_RF_MSG.SYNC_BYTE);         

                //SetText(System.Convert.ToString(escapeptr));
                escaped[7] = System.Convert.ToByte(escapeptr - 10);        
            }

            return escaped;
        }

        /* Slow implementation of crc function */
        static uint16_t crc_byte(uint16_t crc, uint8_t b)			// - 10번
        {
            uint8_t i;

            crc = ((uint16_t)(crc ^ b)) << 8;
            i = 8;
            do
            {
                if ((crc & 0x8000) != 0)
                    crc = crc << 1 ^ 0x1021;
                else
                    crc = crc << 1;
            } while (--i > 0);

            return crc;
        }

        static void escape_byte(uint8_t b)			// - 9번
        {
            crc = crc_byte(crc, b);

            if (b.Equals(DEF_RF_MSG.SYNC_BYTE) || b.Equals(DEF_RF_MSG.ESCAPE_BYTE))
            {
                escaped[escapeptr++] = System.Convert.ToByte(DEF_RF_MSG.ESCAPE_BYTE);
                escaped[escapeptr++] = System.Convert.ToByte(b ^ 0x20);
            }
            else
            {
                escaped[escapeptr++] = System.Convert.ToByte(b);
            }
        }
    }
}
